using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Skin : DateEntry
    {
        //[Key]
        public int SkinID { get; set; }

        //[Key]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}