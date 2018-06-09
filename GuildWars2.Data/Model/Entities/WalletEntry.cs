using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class WalletEntry : DateEntry
    {
        [Key]
        public int ID { get; set; }
        
        public int AccountID { get; set; }
        
        public int CurrencyID { get; set; }

        public int Value { get; set; }

        public int Delta { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }
    }
}