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
            if (connectionStringListbox.SelectedItem == null)
                return null;

            return connectionStringListbox.SelectedItem.ToString();
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
    }
}
