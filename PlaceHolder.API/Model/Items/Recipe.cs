using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class Recipe
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("type")]
        public RecipeType Type { get; set; }

        [JsonProperty("output_item_id")]
        public int OutputItemID { get; set; }

        [JsonProperty("output_item_count")]
        public int OutputItemCount { get; set; }

        /// <summary>
        /// Time to craft in Milliseconds
        /// </summary>
        [JsonProperty("time_to_craft_ms")]
        public int TimeToCraft { get; set; }

        [JsonProperty("disciplines")]
        public List<Discipline> Disciplines { get; set; }

        [JsonProperty("min_rating")]
        public int MinRating { get; set; }

        [JsonProperty("flags")]
        public List<RecipeFlag> Flags { get; set; }

        [JsonProperty("ingredients")]
        public List<RecipeIngredient> Ingredients { get; set; } 

        [JsonProperty("guild_ingredients")]
        public List<RecipeGuildIngredient> GuildIngredients { get; set; } 

        [JsonProperty("output_upgrade_id")]
        public int OutputUpgradeID { get; set; }

        [JsonProperty("chat_link")]
        public string ChatLink { get; set; }
    }

    public enum RecipeType
    {
        Amulet,
        Backpack,
        Bag,
        Boots,
        Bulk,
        Coat,
        Component,
        Consumable,
        Dessert,
        Dye,
        Earring,
        Feast,
        Food,
        Gloves,
        Helm,
        IngredientCooking,
        Inscription,
        Insignia,
        Jewel,
        LegendaryComponent,
        Leggings,
        Meal,
        Potion,
        Refinement,
        RefinementEctoplasm,
        RefinementObsidian,
        Ring,
        Seasoning,
        Shoulders,
        Snack,
        Soup,
        UpgradeComponent,
        Axe,
        LongBow,
        ShortBow,
        Dagger,
        Focus,
        Greatsword,
        Hammer,
        Harpoon,
        Mace,
        Pistol,
        Rifle,
        Scepter,
        Shield,
        Speargun,
        Staff,
        Sword,
        Torch,
        Trident,
        Warhorn,
        GuildConsumable,
        GuildDecoration,
        GuildConsumableWvw
    }

    public enum RecipeFlag
    {
        AutoLearned,
        LearnedFromItem
    }
}
