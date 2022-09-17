using System.Collections;
using optimalDb.Interfaces;

namespace optimalDb.BL;

public enum DatabaseObjectTypeEnum
{
    Unknown,
    Table,
    View, 
    Procedure, 
    Function
}

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