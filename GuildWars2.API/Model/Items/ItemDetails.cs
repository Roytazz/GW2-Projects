using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Items
{
    public class ItemDetails    
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("weight_class")]
        public WeightClass WeightClass { get; set; }
        
        [JsonProperty("defense")]
        public int Defense { get; set; }
        
        [JsonProperty("infusion_slots")]
        public List<Infusion> InfusionSlots { get; set; }
        
        [JsonProperty("infix_upgrade")]
        public Infix InfixUpgrade { get; set; }
        
        [JsonProperty("suffix_item_id")]
        public int SuffixItemID { get; set; }
        
        [JsonProperty("secondary_suffix_item_id")]
        public string SecondarySuffixItemID { get; set; }

        [JsonProperty("stat_choices")]
        public List<int> StatChoices { get; set; }
        
        [JsonProperty("size")]
        public int Size { get; set; }
        
        [JsonProperty("no_sell_or_sort")]
        public bool NoSellOrSort { get; set; }
        
        public string Description { get; set; }
        
        [JsonProperty("duration_ms")]
        public int DurationMS { get; set; }
        
        [JsonProperty("unlock_type")]
        public ConsumableUnlockType UnlockType { get; set; }
        
        [JsonProperty("color_id")]
        public int ColorID { get; set; }
        
        [JsonProperty("recipe_id")]
        public int RecipeID { get; set; }

        [JsonProperty("apply_count")]
        public int ApplyCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minipet_id")]
        public int MiniPetID { get; set; }
        
        [JsonProperty("charges")]
        public int Charges { get; set; }
        
        [JsonProperty("flags")]
        public List<string> Flags { get; set; }
        
        [JsonProperty("infusion_upgrade_flags")]
        public List<InfusionUpgradeFlag> InfusionUpgradeFlags { get; set; }
        
        [JsonProperty("suffix")]
        public string Suffix { get; set; }
        
        [JsonProperty("bonuses")]
        public List<string> Bonuses { get; set; }
        
        [JsonProperty("damage_type")]
        public DamageType DamageType { get; set; }
        
        [JsonProperty("min_power")]
        public int MinPower { get; set; }
        
        [JsonProperty("max_power")]
        public int MaxPower { get; set; }
    }

    public enum ConsumableUnlockType
    {
        BagSlot,
        BankTab,
        CollectibleCapacity,
        Content,
        CraftingRecipe,
        Dye,
        Outfit,
        GliderSkin,
        Champion
    }
}