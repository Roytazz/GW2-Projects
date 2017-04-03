using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GuildWars2.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApiKeyInfo> ApiKeys { get; set; }

        public ApplicationUser() {
            ApiKeys = new HashSet<ApiKeyInfo>();
        }
    }
} 