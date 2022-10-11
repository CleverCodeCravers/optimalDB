namespace optimalDb.Contracts;

public class DatabaseObjectWithCode : IDatabaseObjectWithCode
{
    public string Schema { get; }
    public string Name { get; }
    public string Fullname { get; }
    public string Code { get; }

    public DatabaseObjectWithCode(string schema, string name, string fullname, string code)
    {
        Schema = schema;
        Name = name;
        Fullname = fullname;
        Code = code;
    }
}