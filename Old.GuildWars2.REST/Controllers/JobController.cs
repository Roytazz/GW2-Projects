using Old.GuildWars2.REST.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Old.GuildWars2.REST.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class JobController : BaseController
    {
        public JobController(AppUserStore userStore) : base(userStore) { }

        [HttpGet]
        public async Task<bool> Index()
        {
            _userStore.Test();
            return await Task.Factory.StartNew(() => { return true; });
        }
    }
}