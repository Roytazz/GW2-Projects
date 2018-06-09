using System.Threading.Tasks;
using GuildWars2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.REST.Controllers
{
    [Route("api/[controller]")]
    public class KeyController : BaseController
    {
        [Authorize, HttpPost]
        public async Task<IActionResult> AddKey([FromBody]APIKey key)
        {
            await AuthAPI.AddKey(UserID, key.Key);
            return Accepted();
        }
    }

    public class APIKey
    {
        public string Key { get; set; }
    }
}