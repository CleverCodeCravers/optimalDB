using System.Text;
using FastColoredTextBoxNS.Text;
using FastColoredTextBoxNS.Types;
using optimalDb.BL;
using optimalDb.BL.AutoUpdates;
using optimalDb.BL.ConfigurationFileFormats;
using optimalDb.BL.Scripting;
using optimalDb.Infrastructure;
using optimalDb.Infrastructure.CodeActions;
using optimalDb.Interfaces;
using optimalDb.WinForms.Properties;
using optimalDb.WinForms.UiExtensions;

namespace optimalDb.WinForms
{
    public partial class DatabaseBrowserForm : Form
    {
        private string _configurationFilePath = null;

        protected List<DatabaseConnection> Connections = new();
        protected List<string> Databases = new();
        protected List<DatabaseObject> DatabaseObjects = new();
        protected List<CodeAction> CodeActions = new();

        private DirectoryInfo? _scriptDirectory = null;

        FulltextSearchableListBoxBehaviour<DatabaseConnection> _searchBehaviourForDatabaseConnections;
        FulltextSearchableListBoxBehaviour<string> _searchBehaviourForDatabaseNames;
        FulltextSearchableListBoxBehaviour<DatabaseObject> _searchBehaviourForDatabaseObjects;

        public DatabaseBrowserForm()
        {
            InitializeComponent();
        }

        private void DatabaseBrowserForm_Load(object sender, EventArgs e)
        {
            LanguageComboBox.SelectedIndex = 0;

            System.Resources.ResourceManager resourceManager = 
                new System.Resources.ResourceManager("optimalDb.WinForms.Properties.Resources", typeof(Resources).Assembly);
            var updateImageStream = resourceManager.GetObject("Update");
            
            UpdateConnectionsButton.Image = updateImageStream as Image;
            UpdateDatabasesButton.Image = updateImageStream as Image;
            UpdateDatabaseObjectsButton.Image = updateImageStream as Image;

            _searchBehaviourForDatabaseConnections = 
                new FulltextSearchableListBoxBehaviour<DatabaseConnection>(ConnectionsListbox, ConnectionsSearchTextbox, ref Connections);

            _searchBehaviourForDatabaseNames =
                new FulltextSearchableListBoxBehaviour<string>(DatabasesListbox, DatabasesSearchTextbox, ref Databases);

            _searchBehaviourForDatabaseObjects = 
                new FulltextSearchableListBoxBehaviour<DatabaseObject>(DatabaseObjectsListBox, DatabaseObjectsSearchTextbox, ref DatabaseObjects);

            CodeActions.Add(new PreviewSourcecodeCodeAction());

            UpdateCodeActionsView();
        }

        private void UpdateCodeActionsView()
        {
            codeActionsCheckedListBox.Items.Clear();
            codeActionsCheckedListBox.Items.AddRange(CodeActions.ToArray());
        }

        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var availableFormats = ConfigurationFileFormatFactory.GetAllFileFormats();

            using var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = availableFormats.FilterForDialogs();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var format = availableFormats.GetMatchingFormatFor(openFileDialog.FileName);

                if (format == null)
                {
                    MessageBox.Show("Sorry, I do not know how to read that format.");
                    return;
                }

                _configurationFilePath = openFileDialog.FileName;

                MouseCursorTools.WithWaitCursor(UpdateConnectionsListView);
            }
        }

        private void UpdateConnectionsListView()
        {
            if (string.IsNullOrWhiteSpace(_configurationFilePath))
                return;

            Connections.Clear();

            try
            {
                var availableFormats = ConfigurationFileFormatFactory.GetAllFileFormats();
                var format = availableFormats.GetMatchingFormatFor(_configurationFilePath);

                var connections = format?.Load(_configurationFilePath);
                if (connections != null)
                    Connections.AddRange(connections);

                Connections.Sort((x, y) => string.CompareOrdinal(x.Name, y.Name));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            Databases.Clear();
            DatabaseObjects.Clear();

            _searchBehaviourForDatabaseConnections.UpdateView();
            _searchBehaviourForDatabaseNames.UpdateView();
            _searchBehaviourForDatabaseObjects.UpdateView();
        }

        private void connectionStringListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MouseCursorTools.WithWaitCursor(UpdateDatabasesListView);
        }

        private void DatabasesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MouseCursorTools.WithWaitCursor(UpdateDatabaseObjectsTreeView);
        }

        private void UpdateDatabasesListView()
        {
            if (ConnectionsListbox.TryGetSelectedItemAs(out DatabaseConnection? connection))
            {
                if (connection == null)
                    return;

                Databases.Clear();

                var databaseAccessor = new DatabaseAccessor(connection.ConnectionString);
                var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

                var databases = schemaRepository.GetDatabaseList();
                Databases.AddRange(databases);

                _searchBehaviourForDatabaseNames.UpdateView();
            }
        }

        private void UpdateDatabaseObjectsTreeView()
        {
            if (!ConnectionsListbox.TryGetSelectedItemAs(out DatabaseConnection? connection))
                return;

            if (!DatabasesListbox.TryGetSelectedItemAs(out string? database))
                return;

            DatabaseObjects.Clear();

            var databaseAccessor = new DatabaseAccessor(connection?.ConnectionString??"", database);
            var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

            var databaseObjects = new List<DatabaseObject>();
            databaseObjects.AddRange(schemaRepository.GetTableList());
            databaseObjects.AddRange(schemaRepository.GetViewList());
            databaseObjects.AddRange(schemaRepository.GetStoredProcedureList());
            databaseObjects.AddRange(schemaRepository.GetFunctionList());

            databaseObjects.Sort((x, y) => string.CompareOrdinal(x.Fullname, y.Fullname));

            DatabaseObjects.AddRange(databaseObjects.ToArray());

            _searchBehaviourForDatabaseObjects.UpdateView();
        }

        private void gotoDatabaseObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ConnectionsListbox.TryGetSelectedItemAs(out DatabaseConnection? connection))
                return;

            if (!DatabasesListbox.TryGetSelectedItemAs(out string? database))
                return;

            using var form = new SelectDatabaseObjectForm(connection?.ConnectionString??"", database??"");
            form.ShowDialog();

            var result = form.Result;

            if (result == null)
                return;

            for (var i = 0; i < DatabaseObjectsListBox.Items.Count; i++)
            {
                var element = DatabaseObjectsListBox.Items[i];
                var databaseObject = element as DatabaseObject;
                if (databaseObject?.Fullname == result.Fullname)
                    DatabaseObjectsListBox.SelectedItem = databaseObject;
            }
        }

        private void executeScriptOnSelectedDatabaseObjectCtrlEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_scriptDirectory == null)
            {
                MessageBox.Show("No Script-Directory has been selected");
                return;
            }

            if (!DatabaseObjectsListBox.TryGetSelectedItemAs(out DatabaseObject? selectedItem))
            {
                MessageBox.Show("No database object selected");
                return;
            }

            if (!ConnectionsListbox.TryGetSelectedItemAs(out DatabaseConnection? databaseConnection))
                return;

            if (!DatabasesListbox.TryGetSelectedItemAs(out string? database))
                return;
            
            var modifier = new ConnectionStringModifier(databaseConnection?.ConnectionString??"");
            var connectionString = modifier.ChangeDatabaseTo(database);

            using var form = new SelectScriptForm(_scriptDirectory);
            
            form.ShowDialog();

            if (form.Result == null) 
                return;

            var fullname = form.Result.FullName;

            var resultingText =
                MouseCursorTools.WithWaitCursor(
                    () => PowershellScripting.ExecuteScript(
                        fullname,
                        connectionString,
                        database ?? "",
                        selectedItem?.Schema ?? "",
                        selectedItem?.Name ?? ""));

            CodeTextbox.Text = resultingText;
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


        private void selectScriptFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var folderBrowserDialog = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                _scriptDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                var scriptFolder = new ScriptFolder(_scriptDirectory.FullName);
                var files = scriptFolder.GetFiles();

                foreach (var file in files)
                {
                    CodeActions.Add(new ExecuteScriptCodeAction(file));
                }

                UpdateCodeActionsView();
            }
        }

        private void UpdateDatabaseObjectsButton_Click(object sender, EventArgs e)
        {
            DatabasesListbox_SelectedIndexChanged(null, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutForm = new AboutForm(VersionInformation.Version, "https://github.com/stho32/optimalDB", "optimalDb");

            aboutForm.ShowDialog();
        }

        private void DatabaseObjectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteCodeActions();
        }

        private void ConnectionsSearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DatabasesSearchTextbox.Focus();
            }
        }

        private void DatabasesSearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DatabaseObjectsSearchTextbox.Focus();
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            ExecuteCodeActions();
        }

        private void ExecuteCodeActions()
        {
            if (!DatabaseObjectsListBox.TryGetSelectedItemAs(out DatabaseObject? databaseObject))
                return;

            if (!ConnectionsListbox.TryGetSelectedItemAs(out DatabaseConnection? connection))
                return;

            if (!DatabasesListbox.TryGetSelectedItemAs(out string? database))
                return;

            var result = new StringBuilder();

            for (var i = 0; i < CodeActions.Count; i++)
            {
                var codeAction = CodeActions[i];
                if (codeActionsCheckedListBox.GetItemChecked(i))
                    result.AppendLine(MouseCursorTools.WithWaitCursor(
                        () =>
                            codeAction.Execute(
                                connection?.ConnectionString ?? "",
                                database ?? "",
                                databaseObject?.Schema ?? "",
                                databaseObject?.Name ?? "",
                                databaseObject?.Type)
                    ));
            }

            CodeTextbox.Text = result.ToString();
        }

        private void performanceOptimizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Something will happen here");
        }

        private void UpdateConnectionsButton_Click(object sender, EventArgs e)
        {
            MouseCursorTools.WithWaitCursor(UpdateConnectionsListView);
        }
    }
}
