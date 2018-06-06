using GuildWars2.API;
using Old.GuildWars2.REST.Database;
using Old.GuildWars2.REST.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Old.GuildWars2.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class KeysController : BaseController
    {
        public KeysController(AppUserStore userStore) : base(userStore) { }

        [HttpGet]
        public async Task<IEnumerable<ApiKey>> Index() {
            return await _userStore.GetKeysAsync(await CurrentUser());
        }

        [HttpPost]
        public async Task<ApiKey> Add([FromBody]ApiKey key) {
            if (key != null) {
                await _userStore.AddKeyAsync(await CurrentUser(), key);
                return key;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            if (ModelState.IsValid) {
                await _userStore.DeleteKeyAsync(await CurrentUser(), id);
            }
        }

        [HttpPut("{id}")]
        public async Task Activate(int id) {
            if (ModelState.IsValid) {
                await _userStore.ActivateKeyAsync(await CurrentUser(), id);
            }
        }
    }
}
