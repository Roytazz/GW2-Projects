using Newtonsoft.Json;

namespace GuildWars2API.Model
{
    class Build
    {
        [JsonProperty("build_id")]
        public int BuildID { get; set; }
    }
}
