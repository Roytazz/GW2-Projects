using GuildWars2API.Model.Guild;
using GuildWars2Guild.Model.ViewModel.Bases;

namespace GuildWars2Guild.Model.ViewModel
{
    class MotdViewModel : DbViewModel<LogEntry>
    {
        public MotdViewModel() : base("motd") { }
    }

    class MemberRankViewModel : DbViewModel<LogEntry>
    {
        public MemberRankViewModel() : base("rank_change") { }
    }

    class MemberEventViewModel : DbViewModel<RosterEventEntry>
    {
        public MemberEventViewModel() : base("joined", "invited", "kick") { }
    }

    class StashItemViewModel : ItemViewModel
    {
        public StashItemViewModel() : base("stash") { }
    }

    class TreasuryViewModel : ItemViewModel
    {
        public TreasuryViewModel() : base("treasury") { }
    }
}
