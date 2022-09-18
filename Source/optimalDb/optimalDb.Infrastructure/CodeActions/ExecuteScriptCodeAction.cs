﻿using optimalDb.BL;
using optimalDb.BL.Scripting;

namespace optimalDb.Infrastructure.CodeActions;

public class ExecuteScriptCodeAction : CodeAction
{
    private readonly string _filename;

    public ExecuteScriptCodeAction(string filename) : base("Script " + filename)
    {
        _filename = filename;
    }

    public override string Execute(string connectionString, string database, string databaseObjectSchema,
        string databaseObjectName, DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        return PowershellScripting.ExecuteScript(
            _filename,
            connectionString,
            database,
            databaseObjectSchema,
            databaseObjectName
        );
    }
}