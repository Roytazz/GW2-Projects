using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Skin : DateEntry
    {
        //[Key]
        public int SkinID { get; set; }

        //[Key]
        [JsonIgnore]
        public int AccountID { get; set; }

        [ForeignKey(nameof(AccountID)), JsonIgnore]
        public Account Account { get; set; }
    }
}