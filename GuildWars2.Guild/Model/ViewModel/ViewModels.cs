using GuildWars2API.Model.Guild;
using GuildWars2Guild.Model.ViewModel.Bases;

namespace GuildWars2Guild.Model.ViewModel
{
    class MotdVM : DbVM<LogEntry>
    {
        public MotdVM() : base("motd") { }
    }

    class MemberRankVM : DbVM<LogEntry>
    {
        public MemberRankVM() : base("rank_change") { }
    }

    class MemberEventVM : DbVM<RosterEventEntry>
    {
        public MemberEventVM() : base("joined", "invited", "kick") { }
    }

    class StashItemVM : ItemVM
    {
        public StashItemVM() : base("stash") { }
    }

    class TreasuryVM : ItemVM
    {
        public TreasuryVM() : base("treasury") { }
    }
}
