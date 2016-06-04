using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Guild.Model.ViewModel
{
    class MemberRosterViewModel : MemberViewModel<RosterEntry>
    {

        public MemberRosterViewModel() : base("joined", "invited", "kick") {
            
        }

        protected override bool OnFilter(object value) {
            return true;
        }
    }
}
