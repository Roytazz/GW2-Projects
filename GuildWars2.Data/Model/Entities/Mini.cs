using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Mini : DateEntry
    {
        //[Key]
        public int MiniID { get; set; }

        public int ItemID { get; set; }

        //[Key]
        [JsonIgnore]
        public int AccountID { get; set; }

        [ForeignKey(nameof(AccountID)), JsonIgnore]
        public Account Account { get; set; }
    }
}
