using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using optimalDb.BL;
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
            var views = schemaRepository.GetViewList();

            for (var i = 0; i < views.Length; i++)
            {
                if (AsyncWorker.CancellationPending)
                {
                    break;
                }

                var view = views[i];

                int percentProgress = (i * 100) / views.Length;
                AsyncWorker.ReportProgress(percentProgress, view);

                try
                {
                    Result.Add(
                        new ViewPerformanceTestResult(
                            view.Fullname,
                            GetDurationOfViewExecution(view.Fullname, _connectionString)
                        ));
                }
                catch (Exception exception)
                {
                    Result.Add(
                        new ViewPerformanceTestResult(
                            view.Fullname,
                            null,
                            exception.Message
                        ));
                }
            }

            var maximumDurationInSeconds = Result.Max(x => x.DurationInSeconds);
            var fakeExceptionDurationInSeconds = (maximumDurationInSeconds??0) +1;

            Result = Result.OrderByDescending(x =>
            {
                var orderValue = x.DurationInSeconds;
                if (!string.IsNullOrWhiteSpace(x.ExceptionMessage))
                    orderValue = fakeExceptionDurationInSeconds;
                return orderValue;
            }).ToList();
        }

        protected decimal GetDurationOfViewExecution(string viewName, string connectionString)
        {
            DateTime start = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM " + viewName;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                }
            }

            decimal result = (decimal)(DateTime.Now - start).TotalSeconds;
            return decimal.Round(result, 2);
        }
        private void AsyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PerformanceProgressBar.Value = e.ProgressPercentage;
            IViewName? viewName = e.UserState as IViewName;
            
            if (viewName != null)
                progressValueLabel.Text = viewName.Fullname;
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
