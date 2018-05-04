using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Account
{
    public class Account
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("world")]
        public int World { get; set; }

        [JsonProperty("commander")]
        public bool Commander { get; set; }

        [JsonProperty("guilds")]
        public List<string> Guilds { get; set; }

        [JsonProperty("access")]
        public List<Access> Access { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("fractal_level")]
        public int FractalLevel { get; set; }

        [JsonProperty("daily_ap")]
        public int DailyAP { get; set; }

        [JsonProperty("monthly_ap")]
        public int MonthlyAP { get; set; }

        [JsonProperty("wvw_rank")]
        public int WvWRank { get; set; }
    }
}