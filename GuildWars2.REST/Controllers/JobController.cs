using GuildWars2.REST.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class JobController : BaseController
    {
        public JobController(AppUserStore userManager) : base(userManager) { }
    }
}