using System.Data;

namespace optimalDb.Infrastructure
{
    public static class DataTableExtensions
    {
        public static T[] ToInstancesOf<T>(this DataTable dataTable, Func<DataRow, T> converter)
        {
            var result = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(converter(row));
            }

            return result.ToArray();
        }
    }
}
