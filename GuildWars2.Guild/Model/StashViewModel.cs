using GuildWars2API.Model.Value;
using GuildWars2Guild.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;

namespace GuildWars2Guild.Model
{
    class StashViewModel : ViewModelBase
    {
        private List<GoldEntry> _log;
        private GoldEntry _selectedRow;

        public GoldEntry SelectedRow
        {
            get { return _selectedRow; }
            set {
                _selectedRow = value;
                NotifyPropertyChanged("MemberTotal");
                NotifyPropertyChanged("GoldLogMember");
                NotifyPropertyChanged("SelectedMember");
            }
        }

        public string SelectedMember
        {
            get {
                if(SelectedRow != null) {
                    return SelectedRow.User;
                }
                return "Total";
            }
        }
            
        public ItemPrice MemberTotal
        {
            get {
                if(SelectedRow != null) {
                    return GetSubTotal(SelectedRow.User);
                }
                return null;
            }
        }

        public ListCollectionView GoldLogTotal { get; set; }

        public ObservableCollection<GoldEntry> GoldLogMember {
            get {
                if(SelectedRow != null) {
                    var results = new ObservableCollection<GoldEntry>(_log.Where(entry => entry.User.Equals(SelectedRow.User)).ToList());
                    return results;
                }
                return new ObservableCollection<GoldEntry>();
            }
        }
        
        public StashViewModel() {
            var stashEntries = DBManager.GetLogEntries("stash").Where(entry => entry.Coins > 0).ToList();

            _log = new List<GoldEntry>();
            stashEntries.ForEach(entry => { _log.Add(Refection.CopyFrom(new GoldEntry(), entry)); });

            GoldLogTotal = new ListCollectionView(_log);
        }

        private ItemPrice GetSubTotal(string username) {
            var goldEntries = _log.Where(entry => entry.User.Equals(username));

            var total = new ItemPrice();
            foreach(var entry in goldEntries) {
                if(entry.Operation.Equals("deposit")) {
                    total.Add(entry.Coins);
                }
                else {
                    total.Subtract(entry.Coins);
                }
            }
            return total;
        }
    }
}