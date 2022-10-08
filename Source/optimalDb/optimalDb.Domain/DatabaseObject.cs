namespace optimalDb.Domain;

public class DatabaseObject : IDatabaseObject
{
    public string Schema { get; }
    public string Name { get; }
    public DatabaseObjectTypeEnum Type { get; }
    public string Fullname => Schema + ".[" + Name + "]";

    public DatabaseObject(string schema, string name, DatabaseObjectTypeEnum type)
    {
        Schema = schema;
        Name = name;
        Type = type;
    }

    public override string ToString()
    {
        return Fullname;
    }

}