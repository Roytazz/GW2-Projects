using GuildWars2.REST.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
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

        protected async Task<AppUser> GetUserAsync(ClaimsPrincipal principal) {
            return await _userStore.FindByNameAsync(principal.Claims.ToList()[0].Value);
        }
    }
}
