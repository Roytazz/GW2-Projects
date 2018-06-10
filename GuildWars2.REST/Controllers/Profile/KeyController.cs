using System.Threading.Tasks;
using GuildWars2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.REST.Controllers.Profile
{
    [Route("api/v1/[controller]")]
    public class KeyController : BaseController
    {
        [Authorize, HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]APIKey key)
        {
            await AuthAPI.AddKey(UserID, key.Key);
            return Accepted();
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> Get() {
            var userKeys = await AuthAPI.GetKeys(UserID);
            return Ok(new { keys = userKeys });
        }
    }

    public class APIKey
    {
        public string Key { get; set; }
    }
}