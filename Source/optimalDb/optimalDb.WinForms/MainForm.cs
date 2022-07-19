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

        protected List<DatabaseConnection> localConnections;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var content = File.ReadAllText(openFileDialog1.FileName);
                JArray configArray = JArray.Parse(content);

                if (localConnections == null)
                {
                    localConnections = new List<DatabaseConnection>();
                }

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

                    localConnections.Add(new DatabaseConnection(name, connectionString));
                }


                for (var i = 0; i < localConnections.Count; i++)
                {
                    connectionsComboBox.Items.Add(localConnections[i].Name);
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
                MessageBox.Show("You have to select a database to test!", "No Databse selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            if (localConnections.Count != 0)
            {
                connectionString = localConnections.Find(connection => connection.Name.Equals(selected)).ConnectionString;
            }

            if (connectionString == "")
            {
                MessageBox.Show("A SQL Database connection URL was not found for the selected Database, make sure this Database has a valid connection URL", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        GetDurationOfViewExecution(row["TABLE_SCHEMA"].ToString() + "." + row["TABLE_NAME"].ToString(), connectionString)
                    ));
            }

            dataGridView1.DataSource = result;
        }

        protected decimal GetDurationOfViewExecution(string viewName, string connectionString)
        {
            DateTime start = DateTime.Now;

            try
            {
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
            ShowCreateDialog();
            
        }


        public void ShowCreateDialog()
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Create Config",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label databaseName = new Label() { Left = 30, Top = 20, Text = "Database Name" };
            TextBox databasetextBox = new TextBox() { Left = 150, Top = 18, Width = 150 };
            Label urlString = new Label() { Left = 30, Top = 60, Text = "Database URL" };
            TextBox urltextbox = new TextBox() { Left = 150, Top = 58, Width = 300 };

            Button confirmation = new Button() { Text = "Save", Left = 350, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(databaseName);
            prompt.Controls.Add(databasetextBox);
            prompt.Controls.Add(urlString);
            prompt.Controls.Add(urltextbox);
            prompt.Controls.Add(confirmation);

            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK )

            {

                if (localConnections == null)
                {
                    localConnections = new List<DatabaseConnection>();
                }

                localConnections.Add(new DatabaseConnection(databasetextBox.Text.ToString(), urltextbox.Text.ToString()));
                connectionsComboBox.Items.Add(databasetextBox.Text.ToString());

            }

        }

    }
}