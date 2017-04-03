using GuildWars2.API.Model.Guild;
using System.Collections.Generic;

namespace GuildWars2.GuildInfo.Models
{
    internal class RankLogEntry : ISheetItem
    {
        LogEntry _entry;
        public RankLogEntry(LogEntry entry) {
            _entry = entry;
        }

        public IList<object> Header() {
            return new List<object> {
                "Date",
                nameof(_entry.User),
                nameof(_entry.Type),
                nameof(_entry.KickedBy),
                nameof(_entry.InvitedBy),
                nameof(_entry.ChangedBy),
                nameof(_entry.OldRank),
                nameof(_entry.NewRank),
            };
        }

        public IList<object> Flatten() {
            return new List<object> {
                _entry.Time.ToShortDateString(),
                _entry.User.ToString(),
                (UserLeft() ? "Left" : _entry.Type.ToString()),
                (string.IsNullOrEmpty(_entry.KickedBy) ? "" : _entry.KickedBy),
                (string.IsNullOrEmpty(_entry.InvitedBy) ? "" : _entry.InvitedBy),
                (string.IsNullOrEmpty(_entry.ChangedBy) ? "" : _entry.ChangedBy),
                (string.IsNullOrEmpty(_entry.OldRank) ? "" : _entry.OldRank),
                (string.IsNullOrEmpty(_entry.NewRank) ? "" : _entry.NewRank)
            };
        }

        private bool UserLeft() {
            if (!string.IsNullOrEmpty(_entry.User) && !string.IsNullOrEmpty(_entry.KickedBy)) {
                return _entry.User.Equals(_entry.KickedBy);
            }
            return false;
        }
    }
}
