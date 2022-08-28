using optimalDb.BL;
using optimalDb.Interfaces;

namespace optimalDb.WinForms
{
    public partial class ConfigListForm : Form
    {
        private readonly List<IDatabaseConnection> _databaseConnections;

        public ConfigListForm(List<IDatabaseConnection> databaseConnections)
        {
            _databaseConnections = databaseConnections;
            InitializeComponent();
        }

        public void UpdateView()
        {
            if (configListView.Items.Count > 0)
                configListView.Items.Clear();

            foreach (IDatabaseConnection connection in _databaseConnections)
            {
                var configs = new ListViewItem(new[] { connection.Name, connection.ConnectionString });
                configListView.Items.Add(configs);
            }
        }

        private void AddConfigButton_Click(object sender, EventArgs e)
        {
            var newConnection = new DatabaseConnection("", "");
            var editForm = new ConfigEditForm(newConnection);
            editForm.ShowDialog();
            _databaseConnections.Add(editForm.Result);
            UpdateView();
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditConfigForm_Load(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
