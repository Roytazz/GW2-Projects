using GuildWars2.Web.Data.Users;
using GuildWars2.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(GwUserManager userManager) : base(userManager) { }

        public async Task<IActionResult> Index() {
            var key = await GetActiveAPIKey();
            var characters = await CharacterAPI.Characters(key.ApiKey);
            characters = characters.OrderBy(c => c.Profession).ToList();
            return View(characters);
        }

        public async Task<IActionResult> GuildTag(string guildID) {
            var guildDetails = await GuildAPI.Details(guildID);
            return View("_GuildTag", guildDetails);
        }
    }
}