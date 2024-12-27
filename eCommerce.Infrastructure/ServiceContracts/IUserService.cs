using eCommerce.Core.DTO;

namespace eCommerce.Infrastructure.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    Task<AuthenticationResponse?> Logout();

}