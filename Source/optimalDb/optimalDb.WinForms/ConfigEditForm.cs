using optimalDb.Contracts;
using optimalDb.Domain;

namespace optimalDb.WinForms
{
    public partial class ConfigEditForm : Form
    {
        private readonly DatabaseConnection _connection;
        public DatabaseConnection Result;
        public ConfigEditForm(DatabaseConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void SaveConfigButtoon_Click(object sender, EventArgs e)
        {
            if (databaseTextBox.Text == null || databaseTextBox.Text == "")
            {
                MessageBox.Show("You have to provide a name for the database you want to add!", "Info");
                return;
            }

            if (URLTextBox.Text == null || URLTextBox.Text == "")
            {
                MessageBox.Show("You have to provide a connection string for the database you want to add!", "Info");
                return;
            }

            Result = new DatabaseConnection(databaseTextBox.Text, URLTextBox.Text);
            Close();
        }
    }
}
