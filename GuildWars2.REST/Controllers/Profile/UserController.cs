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
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]UserModel user) {
            var result = await AuthAPI.AddUser(user.UserName, user.Password);
            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(ReturnError(result.Message));
        }
    }
}