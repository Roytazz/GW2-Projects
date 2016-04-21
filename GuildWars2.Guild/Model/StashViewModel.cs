using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GuildWars2Guild.Model
{
    class StashViewModel : INotifyPropertyChanged
    {
        private List<LogEntry> _log;
        private GoldEntry _selectedRow;

        public ObservableCollection<GoldEntry> GoldLogMember {
            get {
                if(SelectedRow != null) {
                    var results = new ObservableCollection<GoldEntry>(GetGoldEntries().Where(entry => entry.LogEntry.User.Equals(SelectedRow.LogEntry.User)).ToList());
                    return results;
                }
                return new ObservableCollection<GoldEntry>();
            }
        }
        public ObservableCollection<GoldEntry> GoldLogTotal { get; set; }

        public GoldEntry SelectedRow {
            get { return _selectedRow; }
            set { _selectedRow = value; NotifyPropertyChanged("GoldLogMember"); }
        }

        public StashViewModel() {
            _log = DBManager.GetLogEntries();
            GoldLogTotal = new ObservableCollection<GoldEntry>(GetGoldEntries());
        }

        private List<GoldEntry> GetGoldEntries() {
            var stachEntries = _log.Where(entry => entry.Type.Equals("stash") && entry.Coins > 0);

            var goldEntries = new List<GoldEntry>();
            foreach(var goldEntry in stachEntries) {
                goldEntries.Add(new GoldEntry() { LogEntry = goldEntry });
            }
            return goldEntries;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}