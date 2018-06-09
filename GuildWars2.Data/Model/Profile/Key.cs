using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Key {

        //[Key]
        public string APIKey { get; set; }

        //[Key]
        public int UserID { get; set; }

        //[Key]
        public int AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
