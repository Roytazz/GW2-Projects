using GuildWars2.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GuildWars2.Web.Data.Users
{
    public class GwSignInManager : SignInManager<ApplicationUser>
    {
        public GwSignInManager(
            GwUserManager userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<GwSignInManager> logger) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger) 
        { }
    }
}
