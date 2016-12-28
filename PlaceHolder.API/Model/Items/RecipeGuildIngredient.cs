using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class RecipeGuildIngredient
    {
        [JsonProperty("upgrade_id")]
        public int ItemID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
