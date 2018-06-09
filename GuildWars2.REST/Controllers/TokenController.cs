using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GuildWars2.Data;
using GuildWars2.Data.Endpoints;
using GuildWars2.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GuildWars2.REST.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : BaseController
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config) {
            _config = config;
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginModel login) {
            var user = await AuthAPI.LoginUser(login.UserName, login.Password);
            if (user != null)
                return Ok(new { token = BuildToken(user) });
            else
                return Unauthorized();
        }

        private string BuildToken(User user) {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], 
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class LoginModel
        {
            public string UserName { get; set; }

            public string Password { get; set; }
        }

        public class UserModel
        {
            public int UserID { get; set; }
        }
    }
}