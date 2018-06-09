using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class WalletEntry : DateEntry
    {
        [Key, JsonIgnore]
        public int ID { get; set; }
        
        [JsonIgnore]
        public int AccountID { get; set; }
        
        public int CurrencyID { get; set; }

        public int Value { get; set; }

        public int Delta { get; set; }

        [ForeignKey(nameof(AccountID)), JsonIgnore]
        public Account Account { get; set; }
    }
}