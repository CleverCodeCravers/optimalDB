namespace optimalDb.Domain;

public interface IDatabaseObject
{
    string Schema { get; }
    string Name { get; }
    string Fullname { get; }
}