using GuildWars2.REST.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Model
{
    public class ApiKey
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public bool Active { get; set; }

        [JsonIgnore]
        public string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual IdentityUser ApplicationUser { get; set; }
    }
}
