using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService(
    IUserRepository userRepository,
    IMapper mapper) : IUserService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
      var user =  await userRepository.GetUserByEmailAndPassword(
            loginRequest.Email,
            loginRequest.Password);

      if (user is null)
      {
          return null;
      }

      var response = mapper.Map<AuthenticationResponse>(user);
      response = response with { Token = "" };
      response = response with { Success = true };

      return response;

    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        var user = mapper.Map<ApplicationUser>(registerRequest);

        var registerResult= await  userRepository.AddUser(user);
     if (registerResult is null)
     {
         return null;
     }

     var response = mapper.Map<AuthenticationResponse>(registerResult);
     response = response with { Token = "token" };
     response = response with { Success = true };

     return response;


    }
}