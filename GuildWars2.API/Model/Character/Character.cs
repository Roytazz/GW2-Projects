using GuildWars2.API.Model.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Character
{
    public class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("race")]
        public Race Race { get; set; }
        
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        
        [JsonProperty("profession")]
        public Profession Profession { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("guild")]
        public string Guild { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("title")]
        public int Title { get; set; }

        [JsonProperty("crafting")]
        public List<CharacterCraftingDiscipline> Crafting { get; set; }

        [JsonProperty("equipment")]
        public List<Equipment> Equipment { get; set; }

        [JsonProperty("bags")]
        public List<Bag> Bags { get; set; }

        [JsonProperty("skills")]
        public Dictionary<GameType, CharacterSkills> Skills { get; set; } 

        [JsonProperty("specializations")]
        public Dictionary<GameType, List<CharacterSpecialization>> Specializations { get; set; }

        [JsonProperty("training")]
        public List<CharacterSkillTree> Training { get; set; } 

        [JsonProperty("wvw_abilities ")]
        public List<WvWAbilities> WvWAbilities { get; set; }

        [JsonProperty("equipment_pvp ")]
        public List<PvPEquipment> PvPEquipment { get; set; }

        [JsonProperty("backstory")]
        public List<string> Backstory { get; set; }

        [JsonProperty("recipes"), Obsolete]
        public List<int> Recipes { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
