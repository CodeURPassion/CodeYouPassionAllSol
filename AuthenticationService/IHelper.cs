using Microsoft.AspNetCore.Identity;

namespace AuthenticationService
{
    public interface IHelper
    {
        string GenerateSecretKey();
        string GenerateJwtToken(string user);
        bool CheckPasswordAsync(string UserName, string Password);
    }
}