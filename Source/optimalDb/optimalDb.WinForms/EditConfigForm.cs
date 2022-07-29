using optimalDb.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace optimalDb.WinForms
{
    public partial class EditConfigForm : Form
    {
        public EditConfigForm()
        {
            InitializeComponent();
        }

        public void AddConfigItems(List<DatabaseConnection> connections)
        {
            if (connections == null) return;

            foreach (DatabaseConnection connection in connections)
            {
                var configs = new ListViewItem(new[] { connection.Name, connection.ConnectionString });
                configList.Items.Add(configs);
            }

        }

        private void AddConfigButton_Click(object sender, EventArgs e)
        {
            var editForm = new AddConfig();
            editForm.Show();
        }
    }
}
