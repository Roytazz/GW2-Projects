using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GuildWars2.REST.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config) {
            _config = config;
        }

        [AllowAnonymous, HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login) {
            var user = Authenticate(login);
            if (user != null)
                return Ok(new { token = BuildToken(user) });
            else
                return Unauthorized();
        }

        private string BuildToken(UserModel user) {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], 
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login) {
            if (login.Password.Equals(_config["GW2:Password"]))  //Obviously make this more secure, but for now it will do
                return new UserModel { UserID = 1 };

            return null;
        }

        public class LoginModel
        {
            public string Password { get; set; }
        }

        public class UserModel
        {
            public int UserID { get; set; }
        }
    }
}