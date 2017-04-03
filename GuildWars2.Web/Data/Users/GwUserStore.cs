using GuildWars2.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Security.Claims;

namespace GuildWars2.Web.Data.Users
{
    public class GwUserStore : UserStore<ApplicationUser>
    {
        private ApplicationDbContext _db;

        public GwUserStore(
            ApplicationDbContext context, 
            IdentityErrorDescriber describer = null) 
            : base(context, describer) 
        {
            _db = context;
        }


        public async Task<List<ApiKeyInfo>> GetKeysAsync(ApplicationUser user) 
        {
            return await _db.ApiKeyInfo.Where(c => c.ApplicationUserId == user.Id).ToListAsync();
        }

        public async Task<int> SetKeysAsync(ApplicationUser user, int id) {
            var keys = await GetKeysAsync(user);
            if (keys.Any(key => key.Id == id)) {
                keys.ForEach(c => c.Active = (c.Id == id));
                _db.ApiKeyInfo.UpdateRange(keys);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
    }
}
