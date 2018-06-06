using Old.GuildWars2.REST.Database;
using Old.GuildWars2.REST.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Old.GuildWars2.REST.Controllers
{
    public abstract class BaseController : Controller
    {
        protected UserManager<IdentityUser> _userManager;
        protected AppUserStore _userStore;

        public BaseController(AppUserStore userStore, UserManager<IdentityUser> userManager = null) {
            _userStore = userStore;
            _userManager = userManager;
        }

        protected async Task<IdentityUser> CurrentUser() {
            return await _userStore.FindByNameAsync(User.Claims.ToList()[0].Value);
        }

        protected async Task<ApiKey> ActiveKey() {
            return await _userStore.GetActiveKey(await CurrentUser());
        }
    }
}
