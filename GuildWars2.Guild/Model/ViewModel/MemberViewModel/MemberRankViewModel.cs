using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuildWars2Guild.Model.ViewModel
{
    class MemberRankViewModel : MemberViewModel<DisplayLogEntry>
    {
        public MemberRankViewModel() : base("rank_change") {
        }

        protected override bool OnFilter(object value) {
            return true;
        }
    }
}
