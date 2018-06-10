using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Controllers
{
    public class BaseController : Controller
    {
        public int UserID {
            get {
                return Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Subject.NameClaimType.Equals(JwtRegisteredClaimNames.Sub))?.Value);
            }
        }

        public object ErrorMessage(string msg) {
            return new { error = msg };
        }
    }
    
    public class UserModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
