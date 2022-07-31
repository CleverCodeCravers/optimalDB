using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using optimalDb.BL;
using optimalDb.Infrastructure;
using optimalDb.WinForms.GridExtras;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using optimalDb.Interfaces;

namespace optimalDb.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<DatabaseConnection> localConnections = new List<DatabaseConnection>();

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
            var selected = connectionsComboBox.SelectedItem as DatabaseConnection;

            if (selected == null)
            {
                MessageBox.Show("You have to select a database to test!", "No Database selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new TestProgressBarForm(
                selected.ConnectionString,
                OnResultArrival
                );
            form.Show();
            form.Start();
        }

        private void OnResultArrival(ViewPerformanceTestResult[] resultFromProcessing)
        {
            try
            {
                dataGridView1.DataSource = new SortableBindingList<ViewPerformanceTestResult>(resultFromProcessing);
                AutoSizeFix.AutoSizeColumns(dataGridView1);

                ColorTheGrid();
                EnableSortingInTheGrid();
                // right align content
                dataGridView1.Columns["DurationInSeconds"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnableSortingInTheGrid()
        {
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void ColorTheGrid()
        {

        }

        private void createConfigItem_Click(object sender, EventArgs e)
        {
            var editForm = new ConfigListForm(localConnections);
            editForm.ShowDialog();
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            decimal warning = 2;
            decimal error = 25;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            var color = Color.White;
            var selectionColor = Color.Blue;

            var durationInSecondsValue = row.Cells["DurationInSeconds"].Value;
            if (durationInSecondsValue == null)
            {
                row.DefaultCellStyle.BackColor = Color.BlueViolet;
                row.DefaultCellStyle.SelectionBackColor = Color.Violet;
                return;
            }

            var durationInSeconds = decimal.Parse(durationInSecondsValue.ToString());
            
            if (durationInSeconds > warning)
            {
                color = Color.Yellow;
                selectionColor = Color.Orange;
            }

            if (durationInSeconds > error)
            {
                color = Color.Red;
                selectionColor = Color.Coral;
            }

            row.DefaultCellStyle.BackColor = color;
            row.DefaultCellStyle.SelectionBackColor = selectionColor;
        }
    }
}
