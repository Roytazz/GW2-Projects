using GuildWars2.API.Model.Guild;
using System.Collections.Generic;
using System;

namespace GuildWars2.GuildInfo.Models
{
    internal class RankLogEntry : ISheetItem
    {
        public LogEntry Entry { get; set; }

        public IList<object> Header() {
            return new List<object> {
                "Date",
                nameof(Entry.User),
                nameof(Entry.Type),
                "By",
                nameof(Entry.OldRank),
                nameof(Entry.NewRank),
            };
        }

        public IList<object> Flatten() {
            return new List<object> {
                Entry.Time.ToShortDateString(),
                Entry.User.ToString(),
                (UserLeft() ? "Left" : Entry.Type.ToString()),
                Entry.GetExecutingName(),
                (string.IsNullOrEmpty(Entry.OldRank) ? "" : Entry.OldRank),
                (string.IsNullOrEmpty(Entry.NewRank) ? "" : Entry.NewRank)
            };
        }

        public void Parse(IList<object> values) {
            Entry = new LogEntry {
                Time = DateTime.Parse(values[0].ToString()),
                User = values[1].ToString(),
                Type = (LogType)Enum.Parse(typeof(LogType), values[2].ToString()),
                KickedBy = values[3].ToString(),
                InvitedBy = values[4].ToString(),
                ChangedBy = values[5].ToString(),
                OldRank = values[6].ToString(),
                NewRank = values[7].ToString()
            };
        }

        private bool UserLeft() {
            if (!string.IsNullOrEmpty(Entry.User) && !string.IsNullOrEmpty(Entry.KickedBy)) {
                return Entry.User.Equals(Entry.KickedBy);
            }
            return false;
        }
    }

    static class Extensions
    {
        internal static string GetExecutingName(this LogEntry entry) {
            if (!string.IsNullOrEmpty(entry.KickedBy))
                return entry.KickedBy;
            else if (!string.IsNullOrEmpty(entry.InvitedBy))
                return entry.InvitedBy;
            else
                return entry.ChangedBy;
        }
    }
}
