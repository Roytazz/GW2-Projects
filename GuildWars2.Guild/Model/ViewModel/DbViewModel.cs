using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System;

namespace GuildWars2Guild.Model.ViewModel
{
    class DbViewModel<T> : BaseViewModel where T : LogEntry, new()
    {
        public List<T> MainCollection { get; set; }

        public DbViewModel(params string[] types) {
            MainCollection = GetEntries(types).OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
        }

        protected virtual List<T> GetEntries(params string[] types) {
            var entries = new List<T>();
            if(types.Length <= 0)
                return entries;

            var stashEntries = LogDbManager.GetLogs(types).ToList();
            stashEntries.ForEach(entry => { entries.Add(Reflection.CopyClass(new T(), entry)); });

            return entries;
        }
    }

    class MotdViewModel : DbViewModel<DisplayLogEntry>
    {
        public MotdViewModel() : base("motd") { }
    }

    class MemberRankViewModel : DbViewModel<DisplayLogEntry>
    {
        public MemberRankViewModel() : base("rank_change") {
        }
    }

    class MemberRosterViewModel : DbViewModel<RosterEntry>
    {
        public MemberRosterViewModel() : base("joined", "invited", "kick") { }
    }
}
