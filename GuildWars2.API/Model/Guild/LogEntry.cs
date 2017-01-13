using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace GuildWars2API.Model.Guild
{
    public class LogEntry
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("time")]
        public DateTime Time { get; set; }   

        [JsonProperty("user")]
        public string User { get; set; }
        
        [JsonProperty("type")]
        public LogType Type { get; set; }

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
        public LogUpgradeAction Action { get; set; }

        #endregion Upgrade
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogType 
    {
        Stash,
        MOTD,
        Invited,
        [EnumMember(Value = "invite_declined")]InviteDeclined,
        Kick,
        Joined,
        [EnumMember(Value = "rank_change")]RankChange,
        Upgrade,
        Influence
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogUpgradeAction   
    {
        Queued,
        Cancelled,
        Completed,
        [EnumMember(Value = "sped_up")]SpedUp
    }

}
