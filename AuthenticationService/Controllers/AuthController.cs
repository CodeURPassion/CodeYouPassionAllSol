using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IHelper _helper;     
        private readonly IConfiguration _configuration;
        public AuthController(IHelper helper, IConfiguration configuration)
        {
            _helper = helper;           
            _configuration = configuration;

        }   
  
        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            string? user =Convert.ToString(model.Username);
            if (user != null &&  _helper.CheckPasswordAsync(user, model.Password))
            {
                var token = _helper.GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
