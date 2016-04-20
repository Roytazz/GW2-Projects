using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GuildWars2Guild.Model
{
    class StashViewModel
    {
        private List<LogEntry> _log;
        public ObservableCollection<GoldEntry> GoldLogEntries { get; set; }

        public StashViewModel() {
            _log = DBManager.GetLogEntries();
            GoldLogEntries = new ObservableCollection<GoldEntry>(GetGoldEntries());
        }

        private List<GoldEntry> GetGoldEntries() {
            var stachEntries = _log.Where(entry => entry.Type.Equals("stash") && entry.Coins > 0);

            var goldEntries = new List<GoldEntry>();
            foreach(var goldEntry in stachEntries) {
                goldEntries.Add(new GoldEntry() { LogEntry = goldEntry });
            }
            return goldEntries;
        }
    }
}