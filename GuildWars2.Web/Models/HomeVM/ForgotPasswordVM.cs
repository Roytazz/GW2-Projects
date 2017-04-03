using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Web.Models.HomeVM
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
