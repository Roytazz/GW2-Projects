using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.Web.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        public IActionResult Index() {
            return View();
        }
    }
}
