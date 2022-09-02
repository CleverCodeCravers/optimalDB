using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using optimalDb.BL;
using optimalDb.BL.TestViewPerformances;
using optimalDb.Infrastructure;
using optimalDb.Interfaces;

namespace optimalDb.WinForms
{
    public partial class TestProgressBarForm : Form
    {
        private string _connectionString;
        private readonly Action<ViewPerformanceTestResult[]> _processCompletedCallback;

        public TestProgressBarForm(string connectionString, 
            Action<ViewPerformanceTestResult[]> processCompletedCallback)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _processCompletedCallback = processCompletedCallback;
        }

        public TestProgressBarForm()
        {
            InitializeComponent();
        }

        public void Start()
        {
            AsyncWorker.RunWorkerAsync();
        }

        public List<ViewPerformanceTestResult> Result = new();

        private void AsyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var databaseAccessor = new DatabaseAccessor(_connectionString);
            var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);
            var process = new ViewPerformanceTestProcess(
                schemaRepository,
                databaseAccessor
                );

            process.GenerateProcessSteps();

            process.Run(
                (text, percent) => AsyncWorker.ReportProgress(percent, text),
                 () => AsyncWorker.CancellationPending
                );


            Result = process.Results;

            var maximumDurationInSeconds = 
                Result.Max(x => x.DurationInSeconds);

            var fakeExceptionDurationInSeconds = 
                (maximumDurationInSeconds??0) +1;

            Result = Result.OrderByDescending(x =>
            {
                var orderValue = x.DurationInSeconds;
                if (!string.IsNullOrWhiteSpace(x.ExceptionMessage))
                    orderValue = fakeExceptionDurationInSeconds;
                return orderValue;
            }).ToList();
        }

        private void AsyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PerformanceProgressBar.Value = e.ProgressPercentage;
            string text = "";
            if (e.UserState != null)
                text = e.UserState.ToString();
            
            progressValueLabel.Text = text;

            if (e.ProgressPercentage == 100)
            {
                progressValueLabel.Text = String.Format("Test Completed {0} %", e.ProgressPercentage);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsyncWorker.CancelAsync();
        }

        private void AsyncWorker_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            _processCompletedCallback(Result.ToArray());
            Close();
        }
    }
}
