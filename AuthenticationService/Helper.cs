using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationService
{
    public class Helper : IHelper
    {

        public string GenerateSecretKey()
        {
            byte[] keyBytes = GenerateRandomKey(32);
            string secretKey = Convert.ToBase64String(keyBytes);
            Console.WriteLine("Generated Secret Key: " + secretKey);
            return secretKey;
        }

        static byte[] GenerateRandomKey(int length)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] keyBytes = new byte[length];
                rng.GetBytes(keyBytes);
                return keyBytes;
            }
        }

        public string GenerateJwtToken(string user)
        {
            string secretKey = "QzDEUlb8C2Z0TREeJeUEb0Tl5/tj9dCdK9Xdndpokdg=";
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool CheckPasswordAsync(string UserName, string Password)
        {
            if(UserName == "TestUser" && Password == "Pass@123")
            {
                return true;
            }
            return false;
        }


    }
}
