using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GuildWars2.Web.Models;
using GuildWars2.Web.Data;
using System.Threading.Tasks;
using GuildWars2.Web.Data.Users;
using GuildWars2.Web.Classes;
using GuildWars2.Web.Models.ManageVM;

namespace GuildWars2.Web.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        public ManageController(GwUserManager userManager, ApplicationDbContext context) 
            : base(userManager, context)
        { }
        
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddKey(ApiKeyInfo model) {
            if (ModelState.IsValid) {
                model.Id = 0;
                model.ApplicationUserId = _userManager.GetUserId(User);

                _db.ApiKeyInfo.Add(model);
                await _db.SaveChangesAsync();
            }
            else {
                return View(nameof(ManageController.Index), model);
            }
            return PartialViewResult("_KeyDisplay");
        }

        [HttpGet]
        public async Task<IActionResult> SetActiveKeyNav(int id, string returnUrl) {
            await _userManager.SetKeysAsync(User, id);
            await SetAPIKey();
            return RedirectToLocal(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> SetActiveKey(int id) {
            await _userManager.SetKeysAsync(User, id);
            await SetAPIKey();
            return PartialViewResult("_KeyDisplay");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteKey(int id) {
            var key = await _db.ApiKeyInfo.FindAsync(id);
            if (key != null && key.ApplicationUserId == _userManager.GetUserId(User)) {
                _db.Remove(key);
                await _db.SaveChangesAsync();
            }
            else {
                ShowNotification("Oops... something went wrong", NotificationType.Error);
            }
            return PartialViewResult("_KeyDisplay");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model) {
            if (ModelState.IsValid) {
                var result = await _userManager.ChangePasswordAsync(await _userManager.GetUserAsync(User), model.OldPassword, model.NewPassword);
                if (!result.Succeeded)
                    ModelState.AddModelError("CurrentPassword", "Your current password is not correct.");
            }
            return View(nameof(ManageController.Index));
        }

        
    }
}