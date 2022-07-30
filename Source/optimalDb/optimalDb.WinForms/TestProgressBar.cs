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
    public partial class TestProgressBar : Form
    {
        BackgroundWorker _bgw;
        public TestProgressBar(BackgroundWorker bgw)
        {
            InitializeComponent();
            _bgw = bgw;
        }


        public void testButtonClicked(object sender, EventArgs e)
        {
            _bgw.DoWork += new DoWorkEventHandler(AsyncWorker_DoWork);
            _bgw.ProgressChanged += new ProgressChangedEventHandler(AsyncWorker_ProgressChanged);
            _bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AsyncWorker_RunWorkerCompleted);
            _bgw.WorkerReportsProgress = true;
            _bgw.RunWorkerAsync();
        }

        private void AsyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = 100;

            for (int i = 0; i <= total; i++) 
            {
                System.Threading.Thread.Sleep(10);
                int percents = (i * 100) / 100;
                _bgw.ReportProgress(percents, i);

            }
        }

        private void AsyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PerformanceProgressBar.Value = e.ProgressPercentage;
            progressValue.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
            if (e.ProgressPercentage == 100)
            {
                progressValue.Text = String.Format("Test Completed {0} %", e.ProgressPercentage);

            }
        }

        private void AsyncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
