using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;
using Dapper;


namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository(ISqlConnectionFactory sqlConnection) : IUserRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        const string query = """
                             
                                         INSERT INTO public."Users" 
                                         ("UserId", "Email", "Name", "Gender", "Password") 
                                         VALUES (@UserId, @Email, @Name, @Gender, @Password)
                             """;

        using var connection = sqlConnection.CreateConnection();

        var rowsAffected = await connection.ExecuteAsync(query, user);

        return rowsAffected > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        const string query = """
                             
                                         SELECT "UserId", "Email", "Name", "Gender", "Password"
                                         FROM public."Users"
                                         WHERE "Email" = @Email AND "Password" = @Password
                             """;

        using var connection = sqlConnection.CreateConnection();

        var user = await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new
        {
            Email = email,
            Password = password
        });

        return user;
    }
}