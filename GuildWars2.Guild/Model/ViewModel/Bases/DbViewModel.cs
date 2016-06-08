using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace GuildWars2Guild.Model.ViewModel.Bases
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
}
