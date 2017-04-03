using GuildWars2.Web.Classes;
using GuildWars2.Web.Data;
using GuildWars2.Web.Data.Users;
using GuildWars2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GuildWars2.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _db;
        protected readonly GwUserManager _userManager;
        protected readonly GwSignInManager _signInManager;

        public BaseController() { }

        public BaseController(GwUserManager userManager = null, ApplicationDbContext context = null, GwSignInManager signInManager = null) {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        protected void ShowNotification(string message, NotificationType type) {
            TempData["Notification"] = new Notification {
                Type = type,
                Message = message
            };
        }

        protected void ShowNotification(string title, string message, NotificationType type) {
            TempData["Notification"] = new Notification {
                Type = type,
                Title = title,
                Message = message
            };
        }

        protected PartialViewResult PartialViewResult(string view) {
            return new PartialViewResult {
                ViewName = view
            };
        }

        protected async Task<ApiKeyInfo> GetActiveAPIKey() {
            var apiKey = TempData["ApiKeys"] as List<ApiKeyInfo>;
            if (apiKey == null) {
                await SetAPIKey();
            }

            return (TempData.Peek("ApiKeys") as List<ApiKeyInfo>).FirstOrDefault(key => key.Active == true);
        }

        protected async Task<List<ApiKeyInfo>> GetAPIKey() {
            var apiKey = TempData["ApiKeys"] as List<ApiKeyInfo>;
            if (apiKey == null) {
                await SetAPIKey();
            }

            return TempData.Peek("ApiKeys") as List<ApiKeyInfo>;
        }

        protected async Task<List<ApiKeyInfo>> SetAPIKey() {
            var keys = await _userManager.GetKeysAsync(User);
            TempData["ApiKeys"] = keys;
            return keys;
        }


        #region Helpers
        protected IActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            else {
                return RedirectToAction(nameof(HomeController.Index));
            }
        }
        #endregion Helpers
    }
}