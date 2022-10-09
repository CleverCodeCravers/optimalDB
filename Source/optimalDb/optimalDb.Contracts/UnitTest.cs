namespace optimalDb.Contracts;

public record UnitTest(
    Guid Id,
    string ConnectionString,
    string Schema,
    string StoredProcedureName
);