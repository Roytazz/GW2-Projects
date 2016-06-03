using GuildWars2API.Model.Value;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace GuildWars2Guild.Model.ViewModel
{
    class StashGoldViewModel : FilterViewModel<GoldEntry>
    {
        public List<GoldEntry> MainCollection { get; set; }

        #region Filter

        public bool CheckDate { get; set; }
        public bool CheckGold { get; set; }
        public bool CheckKeyword { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GoldValue { get; set; }
        public string KeywordValue { get; set; }

        protected override bool OnFilter(object value) {
            var item = value as GoldEntry;
            var result = true;

            if(CheckDate)
                result = IsBetweenDates(item.Time, StartDate, EndDate);

            if(CheckGold && GoldValue?.Length > 0 && result)
                result = IsBiggerAmount(item.Value.Gold, int.Parse(GoldValue));

            if(CheckKeyword && result)
                result = ContainsKeyword(KeywordValue, item.User) || ContainsKeyword(KeywordValue, item.Operation);

            return result;
        }

        #endregion Filter

        #region Selected Member

        private GoldEntry _selectedRow;

        public GoldEntry SelectedRow {
            get {
                if(_selectedRow == null) {
                    if(MainCollection?.Count > 0) {
                        return MainCollection[0];
                    }
                    else {
                        return new GoldEntry();
                    }
                }

                return _selectedRow;
            }
            set {
                _selectedRow = value;
                NotifyPropertyChanged(nameof(MemberTotal));
                NotifyPropertyChanged(nameof(GoldLogMember));
                NotifyPropertyChanged(nameof(SelectedMember));
            }
        }

        public string SelectedMember {
            get {
                if(SelectedRow == null || string.IsNullOrEmpty(SelectedRow.User)) {
                    return "";
                }
                return SelectedRow.User;
            }
        }

        public ItemPrice MemberTotal => GetSubTotal(SelectedRow?.User);

        public ICollectionView GoldLogMember => CollectionViewSource.GetDefaultView(MainCollection?.Where(entry => entry.User.Equals(SelectedRow?.User)).ToList());

        private ItemPrice GetSubTotal(string username) {
            var goldEntries = MainCollection?.Where(entry => entry.User.Equals(username));
            if(goldEntries == null)
                return null;

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

        #endregion Selected Member

        public StashGoldViewModel() {
            MainCollection = GetStashEntries().OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<GoldEntry> GetStashEntries() {
            var goldEntries = new List<GoldEntry>();

            var stashEntries = LogDbManager.GetLogEntries("stash").Where(entry => entry.Coins > 0).ToList();
            stashEntries.ForEach(entry => { goldEntries.Add(Reflection.CopyFrom(new GoldEntry(), entry)); });

            return goldEntries;
        }
    }
}