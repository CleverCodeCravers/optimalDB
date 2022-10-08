using System.Data;
using System.Data.SqlClient;

namespace optimalDb.Domain;

public class DatabaseAccessor : IDatabaseAccessor
{
    private readonly string _connectionString;
    private readonly string? _database;

    public DatabaseAccessor(string connectionString, string? database = "")
    {
        _connectionString = connectionString;
        _database = database;

        var connectionStringModifier = new ConnectionStringModifier(_connectionString);
        _connectionString = connectionStringModifier.ChangeDatabaseTo(_database);
    }

    public DataTable LoadDataTable(string sql, Dictionary<string, object> parameters = null, int timeoutInSeconds = 15)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(sql, connection))
            {
                command.CommandText = sql;
                command.CommandTimeout = timeoutInSeconds;

                AddParameters(command, parameters);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset.Tables[0];
            }
        }
    }

    private void AddParameters(SqlCommand command, Dictionary<string, object> parameters)
    {
        if (parameters == null)
            return;

        foreach(var parameter in parameters)
        {
            var parameterName = parameter.Key;
            if (!parameterName.StartsWith("@"))
            {
                parameterName = "@" + parameterName;
            }
            command.Parameters.AddWithValue(parameterName, parameter.Value);
        }
    }

    public int Execute(string sql, Dictionary<string, object> parameters, int timeoutInSeconds = 15)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(sql, connection))
            {
                command.CommandText = sql;
                command.CommandTimeout = timeoutInSeconds;

                AddParameters(command, parameters);

                return command.ExecuteNonQuery();
            }
        }
    }
}