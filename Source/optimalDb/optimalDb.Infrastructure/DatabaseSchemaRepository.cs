using System.Data;
using System.Text;
using optimalDb.BL;
using optimalDb.Interfaces;

namespace optimalDb.Infrastructure
{
    public class DatabaseSchemaRepository
    {
        private readonly DatabaseAccessor _accessor;

        public DatabaseSchemaRepository(DatabaseAccessor accessor)
        {
            _accessor = accessor;
        }

        public IViewName[] GetViewList()
        {
            var sql = @"
                SELECT t.TABLE_SCHEMA, t.TABLE_NAME
                  FROM INFORMATION_SCHEMA.TABLES t
                 WHERE t.TABLE_TYPE = 'VIEW'";

            var data = _accessor.LoadDataTable(sql);

            return data.ToInstancesOf(
                row =>
                    new ViewName(row["TABLE_SCHEMA"].ToString(),
                        row["TABLE_NAME"].ToString())
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
    }
}
