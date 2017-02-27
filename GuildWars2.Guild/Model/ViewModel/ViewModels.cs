using GuildWars2API.Model.Guild;
using GuildWars2Guild.Model.ViewModel.Bases;

namespace GuildWars2Guild.Model.ViewModel
{
    class MotdVM : DbVM<LogEntry>
    {
        public MotdVM() : base(LogType.MOTD) { }
    }

    class MemberRankVM : DbVM<LogEntry>
    {
        public MemberRankVM() : base(LogType.RankChange) { }
    }

    class MemberEventVM : DbVM<RosterEventEntry>
    {
        public MemberEventVM() : base(LogType.Joined, LogType.Invited, LogType.Kick) { }
    }

    class StashItemVM : ItemVM
    {
        public StashItemVM() : base(LogType.Stash) { }
    }

    class TreasuryVM : ItemVM
    {
        public TreasuryVM() : base(LogType.Treasury) { }
    }
}
