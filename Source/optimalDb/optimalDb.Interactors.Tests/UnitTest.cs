namespace optimalDb.Interactors.Tests;

public record UnitTest(
    Guid Id,
    string ConnectionString,
    string Schema,
    string StoredProcedureName,
    string StoredProcedureCode
);