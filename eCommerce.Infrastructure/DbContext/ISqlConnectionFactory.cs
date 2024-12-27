using System.Data;

namespace eCommerce.Infrastructure.DbContext;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}