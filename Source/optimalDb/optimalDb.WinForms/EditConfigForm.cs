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
        private MainForm _mainForm;
        public EditConfigForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;        
        }

        public void AddConfigItems()
        {
            if (_mainForm.localConnections == null) return;
            foreach (DatabaseConnection connection in _mainForm.localConnections)
            {
                var configs = new ListViewItem(new[] { connection.Name, connection.ConnectionString });
                configList.Items.Add(configs);
            }

        }

        private void AddConfigButton_Click(object sender, EventArgs e)
        {
            var editForm = new AddConfig(_mainForm);
            editForm.Show();

        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
