using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class WalletEntry : DateEntry
    {
        [Key]
        public int ID { get; set; }
        
        public int UserID { get; set; }
        
        public int CurrencyID { get; set; }

        public int Amount { get; set; }

        public int Delta { get; set; }
    }
}