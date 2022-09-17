using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using optimalDb.BL;
using optimalDb.Infrastructure;
using optimalDb.Interfaces;

namespace optimalDb.WinForms
{
    public partial class SelectDatabaseObjectForm : Form
    {
        private readonly string _connectionString;
        private readonly string _database;

        public SelectDatabaseObjectForm()
        {
            InitializeComponent();
        }

        public SelectDatabaseObjectForm(string connectionString, string database)
        {
            _connectionString = connectionString;
            _database = database;
            InitializeComponent();
        }


        public DatabaseObject? Result { get; private set; }
        protected DatabaseObject[] DatabaseObjects { get; private set; }

        private void SelectDatabaseObjectForm_Load(object sender, EventArgs e)
        {
            var databaseAccessor = new DatabaseAccessor(_connectionString, _database);
            var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

            var objects = new List<DatabaseObject>();

            objects.AddRange(schemaRepository.GetTableList());
            objects.AddRange(schemaRepository.GetViewList());
            objects.AddRange(schemaRepository.GetStoredProcedureList());
            objects.AddRange(schemaRepository.GetFunctionList());

            DatabaseObjects = objects.ToArray();
            DatabaseObjectsListBox.Items.AddRange(DatabaseObjects);

            SearchTextbox.Text = "";
            SearchTextbox.Focus();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (DatabaseObjectsListBox.SelectedItem == null)
                return;

            Result = DatabaseObjectsListBox.SelectedItem as DatabaseObject;
            Close();
        }

        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            var query = SearchTextbox.Text.ToLower().Split(" ");

            var subselection = DatabaseObjects.Where(x => Volltexttreffer(x, query)).ToArray();

            DatabaseObjectsListBox.Items.Clear();
            DatabaseObjectsListBox.Items.AddRange(subselection);

            if (DatabaseObjectsListBox.Items.Count > 0)
                DatabaseObjectsListBox.SelectedItem = DatabaseObjectsListBox.Items[0];
        }

        private bool Volltexttreffer(DatabaseObject databaseObject, string[] query)
        {
            if (query.Length == 0)
                return true;

            var objectName = databaseObject.Fullname.ToLower();

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
                if (DatabaseObjectsListBox.SelectedIndex > 0)
                {
                    DatabaseObjectsListBox.SelectedIndex -= 1;
                    e.Handled = true;
                }
            }

            if (e.KeyData == Keys.Down)
            {
                if (DatabaseObjectsListBox.SelectedIndex < DatabaseObjectsListBox.Items.Count-1)
                {
                    DatabaseObjectsListBox.SelectedIndex += 1;
                    e.Handled = true;
                }
            }
        }
    }
}
