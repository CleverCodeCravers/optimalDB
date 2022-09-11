using System.Diagnostics;
using FastColoredTextBoxNS;
using FastColoredTextBoxNS.Text;
using FastColoredTextBoxNS.Types;
using optimalDb.BL;
using optimalDb.BL.ConfigurationFileFormats;
using optimalDb.Infrastructure;
using optimalDb.Interfaces;

namespace optimalDb.WinForms
{
    public partial class DatabaseBrowserForm : Form
    {
        protected List<IDatabaseConnection> Connections = new();

        public DatabaseBrowserForm()
        {
            InitializeComponent();
        }

        private void PleaseWait(Action action)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                action();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var availableFormats = ConfigurationFileFormatFactory.GetAllFileFormats();

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = availableFormats.FilterForDialogs();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var format = availableFormats.GetMatchingFormatFor(openFileDialog.FileName);

                    if (format == null)
                    {
                        MessageBox.Show("Sorry, I do not know how to read that format.");
                        return;
                    }

                    Connections.Clear();

                    try
                    {
                        var connections = format.Load(openFileDialog.FileName);
                        if (connections != null)
                            Connections.AddRange(connections);

                        Connections.Sort((x,y) => string.CompareOrdinal(x.Name, y.Name));
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    PleaseWait(UpdateConnectionsListView);
                }
            }
        }

        private void UpdateConnectionsListView()
        {
            connectionStringListbox.Items.Clear();
            connectionStringListbox.Items.AddRange(Connections.ToArray());
            DatabasesListbox.Items.Clear();
            DatabaseObjectsTreeView.Nodes.Clear();
        }

        private string? GetSelectedConnectionString()
        {
            var connection = connectionStringListbox.SelectedItem as IDatabaseConnection;
            if (connection != null)
                return connection.ConnectionString;

            return null;
        }

        private string? GetSelectedDatabase()
        {
            if (DatabasesListbox.SelectedItem == null)
                return null;

            return DatabasesListbox.SelectedItem.ToString();
        }

        private void connectionStringListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PleaseWait(UpdateDatabasesListView);
        }

        private void UpdateDatabasesListView()
        {
            var connectionString = GetSelectedConnectionString();
            if (connectionString == null)
                return;

            DatabasesListbox.Items.Clear();

            var databaseAccessor = new DatabaseAccessor(connectionString);
            var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

            var databases = schemaRepository.GetDatabaseList();

            DatabasesListbox.Items.AddRange(databases);
        }

        private void DatabasesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PleaseWait(UpdateDatabaseObjectsTreeView);
        }

        private void UpdateDatabaseObjectsTreeView()
        {
            var connectionString = GetSelectedConnectionString();
            if (connectionString == null)
                return;

            var database = GetSelectedDatabase();
            if (database == null)
                return;

            DatabaseObjectsTreeView.Nodes.Clear();

            var databaseAccessor = new DatabaseAccessor(connectionString, database);
            var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

            AddDatabaseObjectsToTreeview("Tables", schemaRepository.GetTableList(), DatabaseObjectsTreeView.Nodes);
            AddDatabaseObjectsToTreeview("Views", schemaRepository.GetViewList(), DatabaseObjectsTreeView.Nodes);
            AddDatabaseObjectsToTreeview("Stored Procedures", schemaRepository.GetStoredProcedureList(), DatabaseObjectsTreeView.Nodes);
            AddDatabaseObjectsToTreeview("Functions", schemaRepository.GetFunctionList(), DatabaseObjectsTreeView.Nodes);

            DatabaseObjectsTreeView.ExpandAll();
            if (DatabaseObjectsTreeView.Nodes.Count > 0)
                DatabaseObjectsTreeView.Nodes[0].EnsureVisible();
        }

        private void AddDatabaseObjectsToTreeview(string sectionName, DatabaseObject[] databaseObjects, TreeNodeCollection nodes)
        {
            var sectionRootNode = new TreeNode(sectionName);

            var schemas = databaseObjects.GroupBy(x => x.Schema);

            foreach (var schema in schemas)
            {
                var schemaNode = new TreeNode(schema.Key);

                foreach (var databaseObject in schema)
                {
                    var node = new TreeNode(databaseObject.Name);
                    node.Tag = databaseObject;

                    schemaNode.Nodes.Add(node);
                }

                sectionRootNode.Nodes.Add(schemaNode);
            }

            nodes.Add(sectionRootNode);
        }

        private void DatabaseObjectsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null)
                return;

            var databaseObject = node.Tag as DatabaseObject;
            if (databaseObject == null)
                return;

            if (databaseObject.Type == DatabaseObjectTypeEnum.Table)
                return;

            var connectionString = GetSelectedConnectionString();
            if (connectionString == null)
                return;

            var database = GetSelectedDatabase();
            if (database == null)
                return;

            var databaseAccessor = new DatabaseAccessor(connectionString, database);
            var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

            CodeTextbox.Text = schemaRepository.GetCode(databaseObject.Fullname);
            CodeTextbox.Selection = new TextSelectionRange(CodeTextbox, 0, 0, 0, 0);
        }

        private void gotoDatabaseObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionString = GetSelectedConnectionString();
            if (connectionString == null)
                return;

            var database = GetSelectedDatabase();
            if (database == null)
                return;

            using (var form = new SelectDatabaseObjectForm(connectionString, database))
            {
                form.ShowDialog();
                var result = form.Result;

                if (result == null)
                    return;

                var nodeToSelect = GetNodeByDatabaseObject(DatabaseObjectsTreeView.Nodes, result);
                DatabaseObjectsTreeView.SelectedNode = nodeToSelect;
            }
        }

        private TreeNode GetNodeByDatabaseObject(TreeNodeCollection nodes, DatabaseObject lookForThis)
        {
            foreach (TreeNode? node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    var childNode = GetNodeByDatabaseObject(node.Nodes, lookForThis);
                    if (childNode != null)
                        return childNode;
                }
                    

                var databaseObject = node.Tag as DatabaseObject;
                if (databaseObject == null)
                    continue;

                if (lookForThis.Fullname == databaseObject.Fullname)
                    return node;
            }

            return null;
        }

        private void DatabaseObjectsTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private DirectoryInfo ScriptDirectory = null;

        private void executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ScriptDirectory == null)
            {
                MessageBox.Show("No Script-Directory has been selected");
                return;
            }

            var node = DatabaseObjectsTreeView.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("No database object selected");
                return;
            }

            var databaseObject = node.Tag as DatabaseObject;
            if (databaseObject == null)
                return;

            var baseConnectionString = GetSelectedConnectionString();
            if (baseConnectionString == null)
                return;

            var database = GetSelectedDatabase();
            if (database == null)
                return;

            var modifier = new ConnectionStringModifier(baseConnectionString);
            var connectionString = modifier.ChangeDatabaseTo(database);

            using (var form = new SelectScriptForm(ScriptDirectory))
            {
                form.ShowDialog();
                if (form.Result != null)
                {
                    var resultingText = ExecuteScript(form.Result.FullName, connectionString, database, databaseObject.Schema, databaseObject.Name);
                    CodeTextbox.Text = resultingText;
                }
            }
        }

        private string ExecuteScript(string scriptFile, string connectionString, string database, string databaseObjectSchema, string databaseObjectName)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var output = "";

                Process process = new Process();
                process.StartInfo.FileName = "C:\\Windows\\System32\\WindowsPowershell\\v1.0\\powershell.exe";
                process.StartInfo.Arguments = "-file \"" + scriptFile + "\"" +
                                              " -ConnectionString \"" + connectionString + "\"" +
                                              " -Database \"" + database + "\"" +
                                              " -Schema \"" + databaseObjectSchema + "\"" +
                                              " -ObjectName \"" + databaseObjectName + "\"";

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                output += process.StandardOutput.ReadToEnd();
                output += process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (output.Contains("###OUTPUTSTARTSHERE###"))
                {
                    output = output.Split("###OUTPUTSTARTSHERE###", 2)[1].Trim();
                }

                return output;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageComboBox.SelectedItem != null)
            {
                if (LanguageComboBox.SelectedText == "C#")
                {
                    CodeTextbox.Language = Language.CSharp;
                }
                if (LanguageComboBox.SelectedText == "T-SQL")
                {
                    CodeTextbox.Language = Language.SQL;
                }
            }
        }

        private void DatabaseBrowserForm_Load(object sender, EventArgs e)
        {
            LanguageComboBox.SelectedIndex = 0;
        }

        private void selectScriptFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    ScriptDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void UpdateDatabaseObjectsButton_Click(object sender, EventArgs e)
        {
            DatabasesListbox_SelectedIndexChanged(null, null);
        }
    }
}
