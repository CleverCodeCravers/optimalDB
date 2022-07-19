using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using optimalDb.BL;
using System.Data;
using System.Data.SqlClient;

namespace optimalDb.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string configFile;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var content = File.ReadAllText(openFileDialog1.FileName);
                this.configFile = content;
                var connections = new List<DatabaseConnection>();

                JArray configArray = JArray.Parse(content);

                foreach (JObject item in configArray) 

                {
                    string name = item.GetValue("Name").ToString();
                    string connectionString = item.GetValue("ConnectionString").ToString();

                    if (connectionString == null)
                    {
                        continue;
                    }

                    if (!connectionString.StartsWith("Server"))
                    {
                        continue;
                    }

                    connections.Add(new DatabaseConnection(name, connectionString));

                }


                for (var i = 0; i < connections.Count; i++)
                {
                    connectionsComboBox.Items.Add(connections[i].Name);
                }


            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            DataTable alleViews;

            string selected = this.connectionsComboBox.GetItemText(this.connectionsComboBox.SelectedItem);
            string connectionString = "";


            if (selected == "")
            {
                MessageBox.Show("You have to select a database to test!", "Error: No Databse selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                JArray configArray = JArray.Parse(this.configFile);

                foreach (JObject item in configArray)

                {
                    string propertyName = item.GetValue("Name").ToString();
                    string urlstring = item.GetValue("ConnectionString").ToString();

                    if (propertyName == selected)
                    {
                        connectionString = urlstring;
                        break;
                    }

                }

            //var connectionString = "Server = .\\SQLEXPRESS; Database = AdventureWorks2019; Trusted_Connection = True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = @"
SELECT t.TABLE_SCHEMA, t.TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES t
 WHERE t.TABLE_TYPE = 'VIEW'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    alleViews = dataset.Tables[0];
                }
            }

            var result = new List<ViewPerformanceTestResult>();
            foreach(DataRow row in alleViews.Rows)
            {
                result.Add(
                    new ViewPerformanceTestResult(
                        row["TABLE_SCHEMA"].ToString() + "." + row["TABLE_NAME"].ToString(),
                        GetDurationOfViewExecution(row["TABLE_SCHEMA"].ToString() + "." + row["TABLE_NAME"].ToString())
                    ));
            }

            dataGridView1.DataSource = result;
        }

        protected decimal GetDurationOfViewExecution(string viewName)
        {
            DateTime start = DateTime.Now;

            try
            {
                var connectionString = "Server = .\\SQLEXPRESS; Database = AdventureWorks2019; Trusted_Connection = True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"SELECT * FROM " + viewName;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            } 
            catch (Exception ex)
            {
                return 999;
            }

            return (decimal)(DateTime.Now - start).TotalSeconds;
        }

        private void createConfigItem_Click(object sender, EventArgs e)
        {

        }

    }
}