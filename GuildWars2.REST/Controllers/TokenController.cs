using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GuildWars2.REST.Controllers
{
    [Route("api/v1/[controller]")]
    public class TokenController : BaseController
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config) {
            _config = config;
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Get([FromBody]UserModel userLogin) {
            var user = await AuthAPI.LoginUser(userLogin.UserName, userLogin.Password);
            if (user != null)
                return Ok(new { token = BuildToken(user) });
            else
                return BadRequest(ErrorMessage("Login credentials are invalid"));
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
    }
}