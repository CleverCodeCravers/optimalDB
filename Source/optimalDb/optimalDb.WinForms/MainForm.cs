using Newtonsoft.Json;
using optimalDb.BL;
using optimalDb.Infrastructure;
using optimalDb.WinForms.GridExtras;
using System.Text;
using optimalDb.BL.AutoUpdates;
using optimalDb.Interfaces;
using System.Diagnostics;
using optimalDb.BL.ConfigurationFileFormats;
using VisualPairCoding.Infrastructure;

namespace optimalDb.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected List<IDatabaseConnection> LocalConnections = new();

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var availableFormats = ConfigurationFileFormatFactory.GetAllFileFormats();

            openFileDialog1.Filter = availableFormats.FilterForDialogs();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var format = availableFormats.GetMatchingFormatFor(openFileDialog1.FileName);

                if (format == null)
                {
                    MessageBox.Show("Sorry, I do not know how to read that format.");
                    return;
                }

                LocalConnections.Clear();

                try
                {
                    var connections = format.Load(openFileDialog1.FileName);
                    if ( connections != null )
                        LocalConnections.AddRange(connections);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
                UpdateConnectionCombobox();
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new TestProgressBarForm(
                    GetSelectedConnectionString(),
                    OnResultArrival
                );
                form.Show();
                form.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "An Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedConnectionString()
        {
            var selected = connectionsComboBox.SelectedItem as DatabaseConnection;

            if (selected == null)
            {
                throw new Exception("You have to select a database to test!");
            }

            return selected.ConnectionString;
        }

        private void UpdateFont()
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Consolas", 12F, GraphicsUnit.Pixel);
            }
        }

        private void OnResultArrival(ViewPerformanceTestResult[] resultFromProcessing)
        {
            try
            {
                dataGridView1.DataSource = new SortableBindingList<ViewPerformanceTestResult>(resultFromProcessing);
                UpdateFont();
                AutoSizeFix.AutoSizeColumns(dataGridView1);

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

        private void createConfigItem_Click(object sender, EventArgs e)
        {
            var editForm = new ConfigListForm(LocalConnections);
            editForm.ShowDialog();
        }

        private void UpdateConnectionCombobox()
        {
            connectionsComboBox.DataSource = LocalConnections.ToArray();
            connectionsComboBox.ValueMember = "ConnectionString";
            connectionsComboBox.DisplayMember = "Name";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formats = ConfigurationFileFormatFactory.GetAllFileFormats();

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = formats.FilterForDialogs();

                saveFileDialog1.Title = "Save Config File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    var format = formats.GetMatchingFormatFor(saveFileDialog1.FileName);
                    if (format == null)
                    {
                        MessageBox.Show("I do not know how to save a file of this format.");
                        return;
                    }

                    format.Save(saveFileDialog1.FileName, LocalConnections.ToArray());
                }
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

#pragma warning disable CS8604 // Mögliches Nullverweisargument.
            var durationInSeconds = decimal.Parse(durationInSecondsValue.ToString());
#pragma warning restore CS8604 // Mögliches Nullverweisargument.

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

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void viewCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as ViewPerformanceTestResult;
                    var accessor = new DatabaseAccessor(GetSelectedConnectionString());
                    var schemaRepository = new DatabaseSchemaRepository(accessor);

                    var view = new ViewSourceCodeForm(selectedRow.ViewName, schemaRepository.GetCode(selectedRow.ViewName));
                    view.ShowDialog();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "An Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForn = new AboutForm(VersionInformation.Version, "https://github.com/stho32/optimalDB", "optimalDb");
            aboutForn.ShowDialog();
        }
    }
}
