using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}