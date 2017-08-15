using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using Newtonsoft.Json;

namespace GuildWars2.Manager.InventoryService
{
    public class ItemStackDifference
    {
        [JsonProperty("itemId")]
        public int ItemID { get; set; }

        [JsonProperty("skinId")]
        public int SkinID { get; set; }

        public int Count { get; set; }

        public int Difference { get; set; }

        public ItemPrice Value { get; set; }

        public override bool Equals(object obj) {
            if (obj is ExtendedItemStack) {
                var item = obj as ExtendedItemStack;
                return item != null && SkinID == item.SkinID && ItemID == item.ID;
            }
            if (obj is ItemStackDifference) {
                var item = obj as ItemStackDifference;
                return item != null && SkinID == item.SkinID && ItemID == item.ItemID;
            }
            return false;
        }

        public override int GetHashCode() {
            int hash = 25;
            unchecked {
                hash = hash * 31 + ItemID;
                hash = hash * 31 + SkinID;
            }
            return hash;
        }
    }

    public class ExtendedItemStack : ItemStack
    {
        [JsonProperty("skinId")]
        public int SkinID { get; set; }

        public override bool Equals(object obj) {
            if (obj is ExtendedItemStack) {
                var item = obj as ExtendedItemStack;
                return item != null && SkinID == item.SkinID && ID == item.ID;
            }
            if(obj is ItemStackDifference) {
                var item = obj as ItemStackDifference;
                return item != null && SkinID == item.SkinID && ID == item.ItemID;
            }
            return false;
        }

        public override int GetHashCode() {
            int hash = 25;
            unchecked { 
                hash = hash * 31 + ID;
                hash = hash * 31 + SkinID;
            }
            return hash;
        }
    }
}
