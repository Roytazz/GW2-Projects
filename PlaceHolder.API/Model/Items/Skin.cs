﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Items
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

        /// <summary>
        /// Race restrictions that apply to the skin, e.g. "Human"
        /// </summary>
        [JsonProperty("restrictions")]
        public List<string> Restrictions { get; set; }

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
        OverrrideRarity
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