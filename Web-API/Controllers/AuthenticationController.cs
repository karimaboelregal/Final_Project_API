using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API.Model.LoginUser;
using Web_API.Model.Register;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;
        private readonly IConfiguration _config;
        public AuthenticationController(UserManager<Admin> userManager, SignInManager<Admin> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register(RegisterUser user)

        {
            Admin u = new Admin() { Email = user.Email, SecurityStamp = Guid.NewGuid().ToString(), UserName = user.Email, JobTitle = "Admin", FullName = user.Email, isActive = true };
            var result = await _userManager.CreateAsync(u, user.Password);
            if (result.Succeeded)
            {

                return StatusCode(StatusCodes.Status201Created);

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var u = await _userManager.FindByEmailAsync(user.Email);

            if (await _userManager.CheckPasswordAsync(u, user.Password))
            {
                var authclaims = new List<Claim>() {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

                };
                var JwtToken = GetToken(authclaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(JwtToken),
                    expiration=JwtToken.ValidTo

                }) ;


            }
            else
            {
                return Unauthorized();
            }
          

        }
        private JwtSecurityToken GetToken(List<Claim> authclaims)
        {
            var authsignkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dadnaojdaodjaojdaoijdojeojdeojwoijweoijwoejf"));


            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims:authclaims,
                signingCredentials:new SigningCredentials(authsignkey,SecurityAlgorithms.HmacSha256)
                ) ;
            return token;
        }
    }
}
