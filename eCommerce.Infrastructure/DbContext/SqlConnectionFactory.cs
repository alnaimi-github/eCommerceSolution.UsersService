using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

internal class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}