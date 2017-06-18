using GuildWars2.API.Model.Guild;
using System;
using System.Collections.Generic;

namespace GuildWars2.GuildInfo.Models
{
    internal class SquireLogEntry : ISheetItem
    {
        public Member Member { get; set; }

        public IList<object> Flatten() {
            return new List<object> {
                Member.Joined.ToShortDateString(),
                Member.Name
            };
        }

        public IList<object> Header() {
            return new List<object> {
                nameof(Member.Joined),
                nameof(Member.Name)
            };
        }

        public void Parse(IList<object> values) {
            Member = new Member {
                Joined = DateTime.Parse(values[0].ToString()),
                Name = values[1].ToString()
            };
        }
    }
}
