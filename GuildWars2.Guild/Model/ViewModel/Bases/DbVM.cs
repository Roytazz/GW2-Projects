using GuildWars2.API.Model.Guild;
using GuildWars2.Guild.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace GuildWars2.Guild.Model.ViewModel.Bases
{
    class DbVM<T> : BaseVM where T : LogEntry, new()
    {
        public List<T> MainCollection { get; set; }

        public DbVM(params LogType[] types) {
            MainCollection = GetEntries(types).OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
        }

        protected virtual List<T> GetEntries(params LogType[] types) {
            var entries = new List<T>();
            if(types.Length <= 0)
                return entries;
            
            foreach(var entry in LogManager.Instance.GetLogs(types).ToList()) {
                entries.Add(Reflection.CopyClass<T, LogEntry>(entry));
            }
            return entries;
        }
    }
}
