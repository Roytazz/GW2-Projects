using GuildWars2.API.Model.Commerce;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class Item
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("chat_link")]
        public string ChatLink { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public ItemType Type { get; set; }

        [JsonProperty("rarity")]
        public ItemRarity Rarity { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("vendor_value")]
        public int VendorValue { get; set; }

        [JsonIgnore]
        public ItemPrice Price { get { return new ItemPrice(VendorValue); } }

        [JsonProperty("default_skin")]
        public int DefaultSkin { get; set; }

        [JsonProperty("flags")]
        public List<ItemFlag> Flags { get; set; }

        [JsonProperty("game_types")]
        public List<GameType> GameTypes { get; set; }

        [JsonProperty("restrictions")]
        public List<ItemRestriction> Restrictions { get; set; }

        [JsonProperty("details")]
        public ItemDetails Details { get; set; }
    }

    public enum ItemType
    {
        Armor,
        Back,
        Bag,
        Consumable,
        Container,
        CraftingMaterial,
        Gathering,
        Gizmo,
        MiniPet,
        Tool,
        Trait,
        Trinket,
        Trophy,
        Weapon,
        UpgradeComponent,
    }

    public enum ItemFlag
    {
        AccountBindOnUse,
        AccountBound,
        BulkConsume,
        DeleteWarning,
        HideSuffix,
        MonsterOnly,
        NoMysticForge,
        NoSalvage,
        NoSell,
        NotUpgradeable,
        NoUnderwater,
        SoulbindOnAcquire,
        SoulBindOnUse,
        Unique
    }

    public enum ItemRestriction
    {
        Asura,
        Charr,
        Human,
        Norn,
        Sylvari,
        Elementalist,
        Engineer,
        Guardian,
        Mesmer,
        Necromancer,
        Ranger,
        Thief,
        Warrior,
        Revenant
    }
}
