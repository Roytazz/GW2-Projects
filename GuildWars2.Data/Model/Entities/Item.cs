using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Item : DateEntry
    {
        [Key]
        public int ID { get; set; }

        public int AccountID { get; set; }

        public int ItemID { get; set; }
        
        public int StatID { get; set; }
        
        public int SkinID { get; set; }

        public CategoryValueType Category { get; set; }

        public int Amount { get; set; }

        public int Delta { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }

        public override bool Equals(object obj) {
            return Equals(obj as Item);
        }

        public bool Equals(Item item) {
            if(item == null)
                return false;
            
            return ItemID == item.ItemID
                && SkinID == item.SkinID
                && StatID == item.StatID
                && Category == item.Category;
        }

        public override int GetHashCode() {
            return (ItemID.GetHashCode() + SkinID.GetHashCode() + StatID.GetHashCode() + Category.GetHashCode()).GetHashCode();
        }
    }
}