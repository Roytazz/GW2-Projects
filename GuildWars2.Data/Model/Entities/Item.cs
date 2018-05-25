using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Item : DateEntry
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int ItemID { get; set; }
        
        public int StatID { get; set; }
        
        public int SkinID { get; set; }

        public int Amount { get; set; }

        public int Delta { get; set; }

        public InventoryType Location { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }

    public enum InventoryType
    {
        Unknown = 0,
        Bank = 1,
        GuildBank = 2,
        Character = 3,
        SharedInventory = 4,
        MaterialStorage = 5,
        DeliveryBox = 6
    }
}