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
    }

    public class ExtendedItemStack : ItemStack
    {
        [JsonProperty("skinId")]
        public int SkinID { get; set; }
    }
}
