using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Guild
{
    public class Rank
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
        
        [JsonProperty("permissions")]
        public List<GuildPermissionType> Permissions { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
