using GuildWars2API.Model.Items;
using GuildWars2Guild.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace GuildWars2Guild.Model.ViewModel
{
    class StashItemViewModel : FilterViewModel<ItemEntry>
    {
        public List<ItemEntry> MainCollection { get; set; }

        #region Selected Item

        private ItemEntry _selectedRow;

        public ItemEntry SelectedRow {
            get {
                if(_selectedRow == null)
                    return MainCollection[0];

                return _selectedRow;
            }
            set {
                _selectedRow = value;
                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }

        public Item SelectedItem {
            get {
                if(SelectedRow != null)
                    return SelectedRow.Item;

                return null;
            }
        }

        #endregion Selected Item

        #region Filter

        public bool CheckDate { get; set; }
        public bool CheckItemCount { get; set; }
        public bool CheckKeyword { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ItemCount { get; set; }
        public string KeywordValue { get; set; }

        protected override bool OnFilter(object value) {
            var item = value as ItemEntry;
            var result = true;

            if(CheckDate)
                result = IsBetweenDates(item.Time);

            if(CheckItemCount && ItemCount?.Length > 0 && result)
                result = IsBiggerAmount(item.Count);

            if(CheckKeyword && result)
                result = ContainsKeyword(item.User) || ContainsKeyword(item.Operation);

            return result;
        }

        private bool IsBetweenDates(DateTime value) => value >= StartDate && value <= EndDate;

        private bool IsBiggerAmount(int value) => value >= int.Parse(ItemCount);

        private bool ContainsKeyword(string value) => value.Contains(KeywordValue);

        #endregion Filter

        public StashItemViewModel() {
            MainCollection = GetStashEntries().OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<ItemEntry> GetStashEntries() {
            var goldEntries = new List<ItemEntry>();
            var stashEntries = DBManager.GetLogEntries("stash").Where(entry => entry.ItemID != 0).ToList();

            List<Item> items = GuildWars2API.ItemAPI.GetItem(stashEntries.Select(entry => entry.ItemID));
            stashEntries.ForEach(entry => { goldEntries.Add(Reflection.CopyFrom(new ItemEntry() { Item = items.Find(item => item.ID == entry.ItemID) }, entry)); });
            return goldEntries;
        }
    }
}