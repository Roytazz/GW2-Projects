using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.REST.Controllers.Profile
{
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]UserModel user) {
            var result = await AuthAPI.AddUser(new User { UserName = user.UserName, Password = user.Password });
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}