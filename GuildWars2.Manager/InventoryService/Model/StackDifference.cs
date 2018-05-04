using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using Newtonsoft.Json;

using static GuildWars2.Manager.StaticInfo;

namespace GuildWars2.Manager.InventoryService
{
    public class ItemStackDifference
    {
        [JsonProperty("itemId")]
        public int ItemID { get; set; }

        [JsonProperty("skinId")]
        public int SkinID { get; set; }

        [JsonProperty("statId")]
        public int StatID { get; set; }

        public int Count { get; set; }

        public int Difference { get; set; }

        public ItemPrice Value { get; set; }

        public override bool Equals(object obj) {
            if (obj is ExtendedItemStack) {
                var item = obj as ExtendedItemStack;
                if (item != null && IsLegendary(ItemID) && IsLegendary(item.ID)) {
                    return item != null && SkinID == item.SkinID && ItemID == item.ID;
                }
                return item != null && SkinID == item.SkinID && ItemID == item.ID && StatID == item.StatID;
            }
            if (obj is ItemStackDifference) {
                var item = obj as ItemStackDifference;
                if (item != null && IsLegendary(ItemID) && IsLegendary(item.ItemID)) {
                    return item != null && SkinID == item.SkinID && ItemID == item.ItemID;
                }
                return item != null && SkinID == item.SkinID && ItemID == item.ItemID && StatID == item.StatID;
            }
            return false;
        }

        public override int GetHashCode() {
            int hash = 25;
            unchecked {
                hash = hash * 31 + ItemID;
                hash = hash * 31 + SkinID;
                if (IsLegendary(ItemID)) {
                    hash = hash * 31 + StatID;
                }
            }
            return hash;
        }
    }

    public class ExtendedItemStack : ItemStack
    {
        [JsonProperty("skinId")]
        public int SkinID { get; set; }

        [JsonProperty("statId")]
        public int StatID { get; set; }

        [JsonIgnore]
        public EquipmentType Type { get; set; }

        public override bool Equals(object obj) {
            if (obj is ExtendedItemStack) {
                var item = obj as ExtendedItemStack;
                if (item != null && IsLegendary(ID) && IsLegendary(item.ID)) {
                    return item != null && SkinID == item.SkinID && ID == item.ID;
                }
                return item != null && SkinID == item.SkinID && ID == item.ID && StatID == item.StatID;
            }
            if(obj is ItemStackDifference) {
                var item = obj as ItemStackDifference;
                if (item != null && IsLegendary(ID) && IsLegendary(item.ItemID)) {
                    return item != null && SkinID == item.SkinID && ID == item.ItemID;
                }
                return item != null && SkinID == item.SkinID && ID == item.ItemID && StatID == item.StatID;
            }
            return false;
        }

        public override int GetHashCode() {
            int hash = 25;
            unchecked { 
                hash = hash * 31 + ID;
                hash = hash * 31 + SkinID;
                if (IsLegendary(ID)) {
                    hash = hash * 31 + StatID;
                }
            }
            return hash;
        }
    }
}
