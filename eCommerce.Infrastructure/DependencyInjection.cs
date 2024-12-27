using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection
            services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnectionString") ??
                               throw new ArgumentNullException(nameof(configuration));

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        return services;
    }
}