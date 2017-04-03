using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GuildWars2.Web.Models;
using GuildWars2.Web.Data.Users;
using Microsoft.AspNetCore.Authorization;
using GuildWars2.Web.Classes;
using GuildWars2.Web.Models.HomeVM;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GuildWars2.Web.Controllers
{
    public class HomeController : BaseController
    {
        RoleManager<IdentityRole> _roleManager;

        public HomeController(GwUserManager userManager, GwSignInManager signInManager, RoleManager<IdentityRole> rm) 
            : base(userManager, signInManager:signInManager) 
        { _roleManager = rm; }
        
        [HttpGet]
        [Authorize]
        public  IActionResult Index() {
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null) {
            if (_signInManager.IsSignedIn(User)) {
                return RedirectToAction(nameof(HomeController.Index));
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded) {
                    return RedirectToLocal(returnUrl);
                }
                else {
                    ModelState.AddModelError(string.Empty, "The combination of username and/or password is not valid.");
                    return View(model);
                }
            }
            return View(model); //Redisplay
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null) {
            if (_signInManager.IsSignedIn(User)) {
                return RedirectToAction(nameof(HomeController.Index));
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model, string returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid) {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
            return View(model); //Redisplay
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff() {
            TempData.Add("null", null);
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword() {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model) {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null) {
                    //Do Something
                }
                ShowNotification("A new password has been send to your email", NotificationType.Succes);
                return RedirectToAction(nameof(HomeController.Login));  // Don't reveal that the user does not exist
            }
            return View(model); //Redisplay
        }

        #region Helpers

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
