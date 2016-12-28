using GuildWars2APIPlaceHolder.Model.Items;
using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class Material : ItemStack
    {
        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("binding")]
        public EntityBinding Binding { get; set; }
    }
}
