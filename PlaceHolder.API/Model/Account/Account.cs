using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class Account
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("world")]
        public int World { get; set; }

        [JsonProperty("commander")]
        public bool Commander { get; set; }

        [JsonProperty("guilds")]
        public List<string> Guilds { get; set; }

        [JsonProperty("access")]
        public Access Access { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("fractal_level")]
        public bool FractalLevel { get; set; }

        [JsonProperty("daily_ap")]
        public bool DailyAP { get; set; }

        [JsonProperty("monthly_ap")]
        public bool MonthlyAP { get; set; }

        [JsonProperty("wvw_rank")]
        public bool WvWRank { get; set; }
    }
}