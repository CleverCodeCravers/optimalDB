using optimalDb.Contracts;

namespace optimalDb.Interactors;

public class UnitTestInteractor
{
    private readonly IUnitTestingRepository _unitTestingRepository;

    public UnitTestInteractor(IUnitTestingRepository unitTestingRepository)
    {
        _unitTestingRepository = unitTestingRepository;
        UnitTestList = Array.Empty<UnitTest>();
    }

    public UnitTest[] UnitTestList { get; private set; }

    private readonly List<UnitTest> _selectedUnitTests = new();
    public UnitTest[] SelectedUnitTests => _selectedUnitTests.ToArray();

    private readonly List<UnitTestResult> _unitTestResults = new();
    public UnitTestResult[] UnitTestResults => _unitTestResults.ToArray();
    
    public event Notify OnUnitTestListChange;
    public event Notify OnSelectedUnitTestsChange;
    public event Notify OnUnitTestResultsChange;

    public void Initialize()
    {
        UpdateUnitTestList();
    }

    public void SelectUnitTest(UnitTest test)
    {
        if (!_selectedUnitTests.Contains(test))
        {
            _selectedUnitTests.Add(test);
            OnSelectedUnitTestsChange?.Invoke();
        }
    }

    public void UnselectUnitTest(UnitTest test)
    {
        if (_selectedUnitTests.Contains(test))
        {
            _selectedUnitTests.Remove(test);
            OnSelectedUnitTestsChange?.Invoke();
        }
    }

    public void SelectAllUnitTests()
    {
        _selectedUnitTests.Clear();
        _selectedUnitTests.AddRange(UnitTestList);
        OnSelectedUnitTestsChange?.Invoke();
    }

    public void UpdateUnitTestList()
    {
        UnitTestList = _unitTestingRepository.DiscoverTests();
        _selectedUnitTests.Clear();
        _unitTestResults.Clear();

        OnUnitTestListChange?.Invoke();
        OnSelectedUnitTestsChange?.Invoke();
        OnUnitTestResultsChange?.Invoke();
    }

    public void RunSelectedTests(IUnitTestRunner unitTestRunner)
    {
        var selectedTests = SelectedUnitTests;
        var results = new List<UnitTestResult>();

        foreach (var test in selectedTests)
        {
            results.Add(unitTestRunner.Run(test));
        }

        UpdateUnitTestResults(results.ToArray());
    }

    private void UpdateUnitTestResults(UnitTestResult[] results)
    {
        _unitTestResults.Clear();
        _unitTestResults.AddRange(results);

        OnUnitTestResultsChange?.Invoke();
    }
}