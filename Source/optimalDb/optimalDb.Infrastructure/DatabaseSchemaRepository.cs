using System.Data;
using System.Text;
using optimalDb.BL;

namespace optimalDb.Infrastructure
{
    

    public class DatabaseSchemaRepository
    {
        private readonly DatabaseAccessor _accessor;

        public DatabaseSchemaRepository(DatabaseAccessor accessor)
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

        public string?[] GetDatabaseList()
        {
            var sql = @"
SELECT name
  FROM sys.databases
 WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')
 ORDER BY name
";

            var data = _accessor.LoadDataTable(sql);
            var databases = data.ToInstancesOf(row => row["name"].ToString());

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
    }
}
