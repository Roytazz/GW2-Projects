using Newtonsoft.Json;
using System;

namespace GuildWars2API.Model.Guild
{
    public class LogEntry
    {
        [JsonProperty("id")]
        public int LogID { get; set; }

        /// <summary>
        /// ISO-8601 format
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }   

        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Possible values (value, explanation):
        /// Stash - A guild member has deposited an item into the guild's treasury. Additonal fields include:
        ///     ItemID - The item ID that was deposited into the treasury
        ///     Count - How many of the specified item was deposited
        ///     Operation - (deposit, withdraw)
        /// MOTD - A guild member has changed the guild's MOTD. Additional fields include:
        ///     MOTD - The new MOTD
        /// Invited - A new person has joined the guild. Additional fields include:
        ///     InvitedBy - The user that invited this person
        /// Upgrade - An upgrade has been performed. Additional fields include:
        ///     Action - (complete, cancelled, qeued)
        ///     UpgradeID
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("upgrade_id")]
        public string UpgradeID { get; set; }

        [JsonProperty("invited_by")]
        public string InvitedBy { get; set; }

        [JsonProperty("item_id")]
        public int ItemID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("coins")]
        public int Coins { get; set; }

        [JsonProperty("motd")]
        public string MOTD { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
