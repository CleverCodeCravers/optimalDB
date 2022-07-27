﻿using System.Data;
using System.Data.SqlClient;

namespace optimalDb.Infrastructure;
public class DatabaseAccessor
{
    private readonly string _connectionString;

    public DatabaseAccessor(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable LoadDataTable(string sql, Dictionary<string, object> parameters, int timeoutInSeconds = 15)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(sql, connection))
            {
                command.CommandText = sql;
                command.CommandTimeout = timeoutInSeconds;
                command.Parameters.Add(parameters);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset.Tables[0];
            }
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
                command.Parameters.Add(parameters);

                return command.ExecuteNonQuery();
            }
        }
    }
}
