using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Web.Models
{
    public class ApiKeyInfo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Key Name")]
        [MinLength(4, ErrorMessage = "Name too short.")]
        public string KeyName { get; set; }

        [Display(Name = "API Key")]
        [MinLength(72, ErrorMessage = "API Key not valid.")]
        public string ApiKey { get; set; }

        public bool Active { get; set; }

        public string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}