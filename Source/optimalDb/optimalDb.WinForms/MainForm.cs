using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using optimalDb.BL;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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

                if (this.localConnections.Count() != 0)
                {
                    // We want to clear the connections list in case a new config was imported and update the combobox
                    this.localConnections.Clear();
                    connectionsComboBox.Items.Clear();
                }



                foreach (JObject item in configArray) 

                {
                    string name = item.GetValue("Name").ToString();
                    string connectionString = item.GetValue("ConnectionString").ToString();

                    if (connectionString == null || connectionString == "")
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
                    connection.Close();
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

                localConnections.Add(new DatabaseConnection(databasetextBox.Text, urltextbox.Text));
                connectionsComboBox.Items.Add(databasetextBox.Text.ToString());

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Config |*.json";
            saveFileDialog1.Title = "Save Config File";
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var config = System.Text.Json.JsonSerializer.Serialize(this.localConnections);
                File.WriteAllText(saveFileDialog1.FileName, config);

            }

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "CSV (*.csv)|*.csv";
                saveFile.FileName = "Output.csv";
                bool fileError = false;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFile.FileName))
                    {
                        try
                        {
                            File.Delete(saveFile.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Could not save the File" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(saveFile.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Test Result saved successfully!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Test Results To Export !!!", "Info");
            }
        }
        }
}
