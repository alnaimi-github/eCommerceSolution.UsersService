namespace eCommerce.Core.DTO;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? Name,
    string? Gender,
    string? Token,
    bool Success
)
{
    public AuthenticationResponse()
        : this(default,default,default,default,default,default)
    {
        
    }
}