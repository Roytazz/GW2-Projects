using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Web.Models.HomeVM
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Stay logged in?")]
        public bool RememberMe { get; set; }
    }
}
