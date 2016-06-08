using GuildWars2Guild.Model.ViewModel.Bases;

namespace GuildWars2Guild.Model.ViewModel
{
    class MotdViewModel : DbViewModel<DisplayLogEntry>
    {
        public MotdViewModel() : base("motd") { }
    }

    class MemberRankViewModel : DbViewModel<DisplayLogEntry>
    {
        public MemberRankViewModel() : base("rank_change") { }
    }

    class MemberRosterViewModel : DbViewModel<RosterEntry>
    {
        public MemberRosterViewModel() : base("joined", "invited", "kick") { }
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
