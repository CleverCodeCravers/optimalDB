namespace optimalDb.Contracts;

public interface IDatabaseObjectWithCode : IDatabaseObject
{
    string Code { get; }
}