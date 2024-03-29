﻿namespace optimalDb.Contracts;

public class DatabaseConnection
{
    public string Name { get; }
    public string ConnectionString { get; }

    public DatabaseConnection(string name, string connectionString)
    {
        Name = name;
        ConnectionString = connectionString;
    }

    public override string ToString()
    {
        return Name;
    }
}