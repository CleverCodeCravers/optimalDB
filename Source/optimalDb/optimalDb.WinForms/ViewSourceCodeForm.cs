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
    public partial class ViewSourceCodeForm : Form
    {
        private readonly string _title;
        private readonly string _code;

        public ViewSourceCodeForm()
        {
            InitializeComponent();
        }
        public ViewSourceCodeForm(string title, string code)
        {
            _title = title;
            _code = code;
            InitializeComponent();
        }

        private void ViewSourceCodeForm_Load(object sender, EventArgs e)
        {
            Text = _title;
            SourceTextBox.Text = _code;
        }
    }
}
