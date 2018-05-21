using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Items
{
    public class Skin
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("flags")]
        public List<SkinFlag> Flags { get; set; }

        [JsonProperty("type")]
        public SkinType Type { get; set; }
        
        [JsonProperty("restrictions")]
        public List<SkinRestriction> Restrictions { get; set; }  

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("rarity")]
        public ItemRarity Rarity { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("details")]
        public SkinDetails Details { get; set; }
    }

    public enum SkinType
    {
        Armor,
        Weapon,
        Back,
        Gathering
    }

    public enum SkinFlag
    {
        ShowInWardrobe,
        NoCost,
        HideIfLocked,
        OverrideRarity
    }

    public enum SkinRestriction
    {
        Human,
        Asura,
        Charr,
        Norn,
        Sylvari
    }
}