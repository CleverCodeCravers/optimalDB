using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using optimalDb.BL;
using optimalDb.Infrastructure;
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

        protected List<DatabaseConnection> localConnections = new List<DatabaseConnection>();

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var content = File.ReadAllText(openFileDialog1.FileName);

                this.localConnections.Clear();

#pragma warning disable CS8604 // Possible null reference argument.
                localConnections.AddRange(JsonConvert.DeserializeObject<DatabaseConnection[]>(content));
#pragma warning restore CS8604 // Possible null reference argument.

                UpdateConnectionCombobox();
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            DataTable alleViews;

            var selected = connectionsComboBox.SelectedItem as DatabaseConnection;

            if (selected == null)
            {
                MessageBox.Show("You have to select a database to test!", "No Database selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var databaseAccessor = new DatabaseAccessor(selected.ConnectionString);
                var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);
                var views = schemaRepository.GetViewList();

                var result = new List<ViewPerformanceTestResult>();

                foreach (string view in views)
                {
                    result.Add(
                        new ViewPerformanceTestResult(
                            view,
                            GetDurationOfViewExecution(view, selected.ConnectionString)
                        ));
                }

                dataGridView1.DataSource = result;

                int columnCount = dataGridView1.Columns.Count;
                decimal warning = 5;
                decimal error = 25;

                for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (dataGridView1.Rows[i - 1].Cells[j].Value.GetType() == typeof(decimal))
                        {
                            decimal value;
                            if (Decimal.TryParse(dataGridView1.Rows[i - 1].Cells[j].Value.ToString(), out value) && value >= warning)
                            {

                                dataGridView1.Rows[i - 1].Cells[j].Style.BackColor = Color.Yellow;

                            }
                            else if (Decimal.TryParse(dataGridView1.Rows[i - 1].Cells[j].Value.ToString(), out value) && value >= error)
                            {

                                dataGridView1.Rows[i - 1].Cells[j].Style.BackColor = Color.Red;

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                localConnections.Add(new DatabaseConnection(databasetextBox.Text, urltextbox.Text));
                UpdateConnectionCombobox();
            }
        }

        private void UpdateConnectionCombobox()
        {
            connectionsComboBox.DataSource = localConnections.ToArray();
            connectionsComboBox.ValueMember = "ConnectionString";
            connectionsComboBox.DisplayMember = "Name";
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
