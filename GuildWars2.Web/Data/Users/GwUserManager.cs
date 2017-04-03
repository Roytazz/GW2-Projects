using GuildWars2.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GuildWars2.Web.Data.Users
{
    public class GwUserManager : UserManager<ApplicationUser>
    {
        private GwUserStore _store;

        public GwUserManager(
            GwUserStore store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<ApplicationUser> passwordHasher, 
            IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<ApplicationUser>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) 
        {
            _store = store;
        }

        public async Task<bool> IsInRoleAsync(ClaimsPrincipal principal, string role) {
            return await IsInRoleAsync(await GetUserAsync(principal), role);
        }

        public async Task<ApiKeyInfo> GetActiveKeyAsync(ClaimsPrincipal principal) {
            var keys = await GetKeysAsync(principal);
            return keys.FirstOrDefault(c => c.Active == true);
        }

        public async Task<List<ApiKeyInfo>> GetKeysAsync(ClaimsPrincipal principal) {
            return await GetKeysAsync(await GetUserAsync(principal));
        }

        protected async Task<List<ApiKeyInfo>> GetKeysAsync(ApplicationUser user) {
            return await _store.GetKeysAsync(user);
        }

        public async Task SetKeysAsync(ClaimsPrincipal principal, int id) {
            await _store.SetKeysAsync(await GetUserAsync(principal), id);
        }
    }
}