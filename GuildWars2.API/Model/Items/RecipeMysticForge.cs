using Newtonsoft.Json;

namespace GuildWars2.API.Model.Items
{
    public class RecipeMysticForge : Recipe
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("output_item_count_range")]
        public string OutputItemCountRange { get; set; }
    }
}
