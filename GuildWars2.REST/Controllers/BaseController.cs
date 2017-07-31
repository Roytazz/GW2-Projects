using GuildWars2.REST.Database;
using GuildWars2.REST.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Controllers
{
    public abstract class BaseController : Controller
    {
        protected AppUserStore _userStore;

        public BaseController(AppUserStore userManager) {
            _userStore = userManager;
        }

        protected async Task<AppUser> CurrentUser() {
            return await _userStore.FindByNameAsync(User.Claims.ToList()[0].Value);
        }

        protected async Task<ApiKey> ActiveKey() {
            return await _userStore.GetActiveKey(await CurrentUser());
        }
    }
}
