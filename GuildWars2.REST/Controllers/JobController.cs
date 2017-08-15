using GuildWars2.REST.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuildWars2.REST.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class JobController : BaseController
    {
        public JobController(AppUserStore userStore) : base(userStore) { }

        [HttpGet]
        public async Task Index()
        {
            _userStore.Test();
        }
    }
}