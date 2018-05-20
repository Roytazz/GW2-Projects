using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Mini : DateEntry
    {
        //[Key]
        public int MiniID { get; set; }

        //[Key]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
