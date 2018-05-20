using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Dye : DateEntry
    {
        //[Key]
        public int DyeID { get; set; }

        //[Key]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
