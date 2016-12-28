using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class RecipeIngredient
    {
        [JsonProperty("item_id")]
        public int ItemID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
