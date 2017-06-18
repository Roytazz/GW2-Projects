using GuildWars2.REST.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Database
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<ApiKey> ApiKeys { get; set; }

        public AppUser() {
            ApiKeys = new HashSet<ApiKey>();
        }
    }
}
