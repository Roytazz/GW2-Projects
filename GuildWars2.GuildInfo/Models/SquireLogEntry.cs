using GuildWars2.API.Model.Guild;
using System.Collections.Generic;

namespace GuildWars2.GuildInfo.Models
{
    internal class SquireLogEntry : ISheetItem
    {
        Member _member;

        public SquireLogEntry(Member entry) {
            _member = entry;
        }

        public IList<object> Flatten() {
            return new List<object> {
                _member.Joined.ToShortDateString(),
                _member.Name
            };
        }

        public IList<object> Header() {
            return new List<object> {
                nameof(_member.Joined),
                nameof(_member.Name)
            };
        }
    }
}
