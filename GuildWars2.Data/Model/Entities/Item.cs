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
            if(obj.GetType() != typeof(Item))
                return false;

            var item = obj as Item;
            return ItemID == item.ItemID
                && SkinID == item.SkinID
                && StatID == item.StatID
                && Category == item.Category;
        }
    }
}