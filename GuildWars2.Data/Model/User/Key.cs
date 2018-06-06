using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Key {

        //[Key]
        public string APIKey { get; set; }

        //[Key]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
