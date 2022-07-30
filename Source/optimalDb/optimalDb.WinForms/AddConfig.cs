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
    public partial class AddConfig : Form
    {

        private MainForm _mainform;
        public AddConfig(MainForm mainform)
        {
            InitializeComponent();
            _mainform = mainform;
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

            _mainform.localConnections.Add(new DatabaseConnection(databaseTextBox.Text, URLTextBox.Text));
            Close();

        }
    }
}
