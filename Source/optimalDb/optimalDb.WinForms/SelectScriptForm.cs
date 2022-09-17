namespace optimalDb.WinForms
{
    public partial class SelectScriptForm : Form
    {
        private readonly DirectoryInfo _scriptFolder;

        public SelectScriptForm()
        {
            InitializeComponent();
        }

        public SelectScriptForm(DirectoryInfo scriptFolder)
        {
            InitializeComponent();
            _scriptFolder = scriptFolder;
        }

        public FileInfo? Result { get; private set; }
        protected FileInfo[] ScriptFiles { get; private set; }

        private void SelectDatabaseObjectForm_Load(object sender, EventArgs e)
        {
            var files = _scriptFolder.GetFiles("*.ps1", SearchOption.AllDirectories);
            ScriptFiles = files;
            SearchTextbox_TextChanged(null, null);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (ScriptFilesListBox.SelectedItem == null)
                return;

            Result = ScriptFilesListBox.SelectedItem as FileInfo;
            Close();
        }

        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            var query = SearchTextbox.Text.ToLower().Split(" ");

            var subselection = ScriptFiles.Where(x => Volltexttreffer(x, query)).ToArray();

            ScriptFilesListBox.Items.Clear();
            ScriptFilesListBox.Items.AddRange(subselection);

            if (ScriptFilesListBox.Items.Count > 0)
                ScriptFilesListBox.SelectedItem = ScriptFilesListBox.Items[0];
        }

        private bool Volltexttreffer(FileInfo scriptFile, string[] query)
        {
            if (query.Length == 0)
                return true;

            var objectName = scriptFile.Name.ToLower();

            foreach (var part in query)
            {
                if (!objectName.Contains(part))
                    return false;
            }

            return true;
        }

        private void SearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Result = null;
                Close();
                e.Handled = true;
            }

            if (e.KeyData == Keys.Enter)
            {
                SelectButton_Click(null, null);
                e.Handled = true;
            }

            if (e.KeyData == Keys.Up)
            {
                if (ScriptFilesListBox.SelectedIndex > 0)
                {
                    ScriptFilesListBox.SelectedIndex -= 1;
                    e.Handled = true;
                }
            }

            if (e.KeyData == Keys.Down)
            {
                if (ScriptFilesListBox.SelectedIndex < ScriptFilesListBox.Items.Count-1)
                {
                    ScriptFilesListBox.SelectedIndex += 1;
                    e.Handled = true;
                }
            }
        }
    }
}
