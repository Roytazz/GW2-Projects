using GuildWars2.REST.Database;
using GuildWars2.REST.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class UserController : BaseController {

        public UserController(AppUserStore userStore, UserManager<AppUser> userManager) : base(userStore, userManager) { }
        
        [HttpPost]
        public async Task<bool> Register([FromBody]RegisterModel model) {
            if (ModelState.IsValid) {
                var user = new AppUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                return result.Succeeded;
            }
            return false;
        }

        [HttpPost]
#pragma warning disable CS1998
        public async Task<bool> ResetPassword([FromBody]ResetPasswordModel model) {
#pragma warning restore CS1998 
            if (ModelState.IsValid) {
                throw new NotImplementedException();
            }
            return false;
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> ChangePassword([FromBody]PasswordResetModel model) {
            if (ModelState.IsValid) {
                var result = await _userManager.ChangePasswordAsync(await CurrentUser(), model.OldPassword, model.NewPassword);
                return result.Succeeded;
            }
            return false;
        }
    }

    public class RegisterModel
    {
        [Required, MinLength(5)]
        public string Username { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        [Required, RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required, MinLength(5)]
        public string Username { get; set; }
    }

    public class PasswordResetModel
    {
        [Required, MinLength(8)]
        public string OldPassword { get; set; }

        [Required, MinLength(8)]
        public string NewPassword { get; set; }
    }
}
