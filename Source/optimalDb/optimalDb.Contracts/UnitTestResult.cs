using System.Data;

namespace optimalDb.Contracts;

public record UnitTestResult(
    UnitTest UnitTest,
    bool IsSuccess,
    string Message,
    DataTable ResultingTable
);