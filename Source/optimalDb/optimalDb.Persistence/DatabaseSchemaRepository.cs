﻿using System.Data;
using System.Text;
using optimalDb.Contracts;

namespace optimalDb.Persistence
{
    public interface IDatabaseSchemaRepository
    {
        DatabaseObject[] GetViewList();
        string GetCode(string name);
        string[] GetDatabaseList();
        DatabaseObject[] GetTableList();
        DatabaseObject[] GetStoredProcedureList();
        DatabaseObject[] GetFunctionList();
        DatabaseColumn[] GetPrimaryKeyList(string schema, string tableOrView);
        DatabaseColumn[] GetColumnsIncludingPrimaryKeys(string schema, string tableOrView);
        DatabaseColumn[] GetColumnList(string schema, string tableOrView);
    }

    public class DatabaseSchemaRepository : IDatabaseSchemaRepository
    {
        private readonly IDatabaseAccessor _accessor;

        public DatabaseSchemaRepository(IDatabaseAccessor accessor)
        {
            _accessor = accessor;
        }

        public DatabaseObject[] GetViewList()
        {
            var sql = @"
SELECT t.TABLE_SCHEMA, t.TABLE_NAME
  FROM INFORMATION_SCHEMA.TABLES t
 WHERE t.TABLE_TYPE = 'VIEW'
 ORDER BY TABLE_SCHEMA, TABLE_NAME
";

            var data = _accessor.LoadDataTable(sql);

            return data.ToInstancesOf(
                row =>
                    new DatabaseObject(
                        row["TABLE_SCHEMA"].ToString(),
                        row["TABLE_NAME"].ToString(),
                        DatabaseObjectTypeEnum.View)
                );
        }

        public string GetCode(string name)
        {
            var sql = "sp_helptext @name";

            var data = _accessor.LoadDataTable(sql, new Dictionary<string, object>
            {
                { "@name", name }
            });

            var result = new StringBuilder();

            foreach (DataRow row in data.Rows)
            {
                result.Append(row["Text"]);
            }

            return result.ToString().Trim();
        }

        public string[] GetDatabaseList()
        {
            var sql = @"
SELECT name
  FROM sys.databases
 WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')
   AND HAS_DBACCESS(name) = 1
 ORDER BY name
";

            var data = _accessor.LoadDataTable(sql);
            var databases = data.ToInstancesOf(row => row["name"].ToString()??"");

            return databases;
        }

        public DatabaseObject[] GetTableList()
        {
            var sql = @"
SELECT t.TABLE_SCHEMA, t.TABLE_NAME
  FROM INFORMATION_SCHEMA.TABLES t
 WHERE t.TABLE_TYPE = 'BASE TABLE'
 ORDER BY TABLE_SCHEMA, TABLE_NAME
";

            var data = _accessor.LoadDataTable(sql);

            return data.ToInstancesOf(row =>
                new DatabaseObject(row["TABLE_SCHEMA"].ToString(), row["TABLE_NAME"].ToString(), DatabaseObjectTypeEnum.Table)
            );
        }

        public DatabaseObject[] GetStoredProcedureList()
        {
            var sql = @"
SELECT t.ROUTINE_SCHEMA, t.ROUTINE_NAME, t.ROUTINE_TYPE
  FROM INFORMATION_SCHEMA.ROUTINES t
 WHERE ROUTINE_TYPE = 'PROCEDURE'
 ORDER BY ROUTINE_SCHEMA, ROUTINE_NAME
";

            var data = _accessor.LoadDataTable(sql);

            return data.ToInstancesOf(row =>
                new DatabaseObject(row["ROUTINE_SCHEMA"].ToString(), row["ROUTINE_NAME"].ToString(), DatabaseObjectTypeEnum.Procedure)
            );
        }

        public DatabaseObject[] GetFunctionList()
        {
            var sql = @"
SELECT t.ROUTINE_SCHEMA, t.ROUTINE_NAME, t.ROUTINE_TYPE
  FROM INFORMATION_SCHEMA.ROUTINES t
 WHERE ROUTINE_TYPE = 'FUNCTION'
 ORDER BY ROUTINE_SCHEMA, ROUTINE_NAME
";

            var data = _accessor.LoadDataTable(sql);

            return data.ToInstancesOf(row =>
                new DatabaseObject(row["ROUTINE_SCHEMA"].ToString(), row["ROUTINE_NAME"].ToString(), DatabaseObjectTypeEnum.Function)
            );
        }

        public DatabaseColumn[] GetPrimaryKeyList(string schema, string tableOrView)
        {
            var sql = @"
SELECT COLUMN_NAME, ORDINAL_POSITION, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE 
   FROM INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME   = @name
    AND TABLE_SCHEMA = @schema
	AND COLUMN_NAME IN (
			SELECT COLUMN_NAME
			  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
			  JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ON ccu.Constraint_Name = tc.Constraint_Name
																 AND ccu.Table_Name	     = tc.Table_Name
			 WHERE Constraint_Type = 'PRIMARY KEY'
			   AND tc.TABLE_SCHEMA = @schema
			   AND tc.TABLE_NAME   = @name
		)
  ORDER BY ORDINAL_POSITION
";

            var data = _accessor.LoadDataTable(sql,
                new Dictionary<string, object>
                {
                    {"@schema", schema},
                    {"@name", tableOrView}
                });

            return data.ToInstancesOf(row =>
                new DatabaseColumn(
                    row["COLUMN_NAME"].ToString() ?? "",
                    row["ORDINAL_POSITION"].ToInt(),
                    row["COLUMN_DEFAULT"].ToString(),
                    row["IS_NULLABLE"].ToString() != "NO",
                    row["DATA_TYPE"].ToString() ?? "",
                    row["CHARACTER_MAXIMUM_LENGTH"].ToInt(),
                    row["NUMERIC_PRECISION"].ToInt(),
                    row["NUMERIC_SCALE"].ToInt()
                ));
        }

        public DatabaseColumn[] GetColumnsIncludingPrimaryKeys(string schema, string tableOrView)
        {
            var result = new List<DatabaseColumn>();

            result.AddRange(GetPrimaryKeyList(schema, tableOrView));
            result.AddRange(GetColumnList(schema, tableOrView));

            return result.ToArray();
        }

        public DatabaseColumn[] GetColumnList(string schema, string tableOrView)
        {
            var sql = @"
 SELECT COLUMN_NAME, ORDINAL_POSITION, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE 
   FROM INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME   = @name
    AND TABLE_SCHEMA = @schema
	AND COLUMN_NAME NOT IN (
			SELECT COLUMN_NAME
			  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
			  JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ON ccu.Constraint_Name = tc.Constraint_Name
																 AND ccu.Table_Name	     = tc.Table_Name
			 WHERE Constraint_Type = 'PRIMARY KEY'
			   AND tc.TABLE_SCHEMA = @schema
			   AND tc.TABLE_NAME   = @name
		)
  ORDER BY ORDINAL_POSITION
";

            var data = _accessor.LoadDataTable(sql,
                new Dictionary<string, object>
                {
                    {"@schema", schema},
                    {"@name", tableOrView}
                });

            return data.ToInstancesOf(row =>
                new DatabaseColumn(
                    row["COLUMN_NAME"].ToString()??"",
                    row["ORDINAL_POSITION"].ToInt(),
                    row["COLUMN_DEFAULT"].ToString(),
                    row["IS_NULLABLE"].ToString() != "NO",
                    row["DATA_TYPE"].ToString()??"",
                    row["CHARACTER_MAXIMUM_LENGTH"].ToInt(),
                    row["NUMERIC_PRECISION"].ToInt(),
                    row["NUMERIC_SCALE"].ToInt()
                ));
        }
    }
}
