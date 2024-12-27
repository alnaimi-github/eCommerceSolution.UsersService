using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContract;

public interface IUserRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email,
        string? password); 
}