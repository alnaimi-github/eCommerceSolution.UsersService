using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(Core.DTO.RegisterRequest registerRequest)
    {
        if (registerRequest is null)
        {
            return BadRequest("Invalid registration data.");
        }

        var response = await userService.Register(registerRequest);
        if (response is null || response.Success is false)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult>Login(Core.DTO.LoginRequest loginRequest)
    {
        if (loginRequest is null)
        {
            return BadRequest("Invalid login data.");
        }
        var response = await userService.Login(loginRequest);
        if (response is null || response.Success is false)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}