using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using optimalDb.BL;
using optimalDb.Infrastructure;

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

                string view = views[i];

                int percentProgress = (i * 100) / views.Length;
                AsyncWorker.ReportProgress(percentProgress, view);

                Result.Add(
                    new ViewPerformanceTestResult(
                        view,
                        GetDurationOfViewExecution(view, _connectionString)
                    ));
            }

            Result = Result.OrderByDescending(x => x.DurationInSeconds).ToList();
        }

        protected decimal GetDurationOfViewExecution(string viewName, string connectionString)
        {
            DateTime start = DateTime.Now;

            try
            {
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
            }
            catch (Exception ex)
            {
                return 999;
            }

            return (decimal)(DateTime.Now - start).TotalSeconds;
        }
        private void AsyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PerformanceProgressBar.Value = e.ProgressPercentage;
            var viewName = e.UserState?.ToString();
            
            progressValueLabel.Text = viewName;
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
