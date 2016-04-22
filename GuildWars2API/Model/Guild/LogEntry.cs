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
        ///     Count OR Coins - How many of the specified item/gold was deposited
        ///     Operation - (deposit, withdraw)
        /// MOTD - A guild member has changed the guild's MOTD. Additional fields include:
        ///     MOTD - The new MOTD
        /// Invited - A new person has been invited to the guild. Additional fields include:
        ///     InvitedBy - The user that invited this person
        /// Kick - A  person has been kicked from the guild. Additional fields include:
        ///     KickedBy - The user that kicked this person
        /// Joined - A new person has joined the guild.
        /// RankChange - A  person has received a new rank. Additional fields include:
        ///     ChangedBy - The user that changed the rank.
        ///     OldRank - Old rank name of the user.
        ///     New Rank - New rank name of the user.
        /// Upgrade - An upgrade has been performed. Additional fields include:
        ///     Action - (complete, cancelled, qeued, sped_up)
        ///     UpgradeID - ID of the upgrade
        [JsonProperty("type")]
        public string Type { get; set; }

        #region Stash

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("coins")]
        public int Coins { get; set; }

        [JsonProperty("item_id")]
        public int ItemID { get; set; }

        #endregion Stash

        #region MOTD

        [JsonProperty("motd")]
        public string MOTD { get; set; }

        #endregion MOTD

        #region Roster

        [JsonProperty("invited_by")]
        public string InvitedBy { get; set; }

        [JsonProperty("kicked_by")]
        public string KickedBy { get; set; }

        [JsonProperty("changed_by")]
        public string ChangedBy { get; set; }

        [JsonProperty("old_rank")]
        public string OldRank { get; set; }

        [JsonProperty("new_rank")]
        public string NewRank { get; set; }

        #endregion Roster

        #region Upgrade

        [JsonProperty("upgrade_id")]
        public string UpgradeID { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        #endregion Upgrade
    }
}
