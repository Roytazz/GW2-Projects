using System.Threading.Tasks;
using GuildWars2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.REST.Controllers
{
    [Route("api/[controller]")]
    public class KeyController : Controller
    {
        [Authorize, HttpPost]
        public async Task<IActionResult> AddKey([FromBody]APIKey key)
        {
            await UserAPI.AddUser(key.Key);
            return Ok();
        }
    }

    public class APIKey
    {
        public string Key { get; set; }
    }
}