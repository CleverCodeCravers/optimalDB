using System.Data;

namespace optimalDb.Interactors.Tests;

public record UnitTestResult(
    UnitTest UnitTest,
    bool IsSuccess,
    string Message,
    DataTable ResultingTable
);