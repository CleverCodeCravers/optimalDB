using optimalDb.Contracts;
using optimalDb.Domain.SqlUnitTests;
using optimalDb.Interactors;

namespace optimalDb.WinForms
{
    public partial class UnitTestRunnerForm : Form
    {
        private readonly UnitTestInteractor _unitTestRunnerInteractor;

        public UnitTestRunnerForm(UnitTestInteractor unitTestRunnerInteractor)
        {
            InitializeComponent();
            _unitTestRunnerInteractor = unitTestRunnerInteractor;
        }

        private void UpdateUnitTestList()
        {
            var unitTests = _unitTestRunnerInteractor.UnitTestList;
            unitTestListBox.DataSource = unitTests;
            unitTestListBox.DisplayMember = "StoredProcedureName";
        }

        private void UnitTestRunnerForm_Load(object sender, EventArgs e)
        {
            _unitTestRunnerInteractor.OnUnitTestListChange += UpdateUnitTestList;
            //_unitTestRunnerInteractor.OnSelectedUnitTestsChange += SelectedUnitTestsChange;
            _unitTestRunnerInteractor.OnUnitTestResultsChange += UnitTestsResultsChange;
            _unitTestRunnerInteractor.Initialize();
        }

        private void UnitTestsResultsChange()
        {
            UnitTestResultListView.Items.Clear();

            foreach (var unitTestResult in _unitTestRunnerInteractor.UnitTestResults)
            {
                var item = new ListViewItem();
                item.Text = unitTestResult.UnitTest.StoredProcedureName;
                item.SubItems.Add(unitTestResult.IsSuccess ? "Yes" : "No");
                item.SubItems.Add(unitTestResult.Message ?? "");
                item.Tag = unitTestResult;
                UnitTestResultListView.Items.Add(item);
            }
        }

        private void runAllTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _unitTestRunnerInteractor.SelectAllUnitTests();
            _unitTestRunnerInteractor.RunSelectedTests(new SqlUnitTestRunner());
        }

        private void UnitTestResultListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultTableDataGridView.DataSource = null;

            if (UnitTestResultListView.SelectedItems.Count == 0)
                return;

            var selectedTestResult = UnitTestResultListView.SelectedItems[0].Tag as UnitTestResult;

            ResultTableDataGridView.DataSource = selectedTestResult?.ResultingTable;
        }
    }
}
