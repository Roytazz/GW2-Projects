using GuildWars2API.Model.Items;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
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
                if(_selectedRow == null) {
                    if(MainCollection?.Count > 0) {
                        return MainCollection?[0];
                    }
                    else {
                        return new ItemEntry();
                    }
                }

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

                return new Item();
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
                result = IsBetweenDates(item.Time, StartDate, EndDate);

            if(CheckItemCount && ItemCount?.Length > 0 && result)
                result = IsBiggerAmount(item.Count, int.Parse(ItemCount));

            if(CheckKeyword && result)
                result = ContainsKeyword(KeywordValue, item.User) || ContainsKeyword(KeywordValue, item.Operation);

            return result;
        }

        #endregion Filter

        public StashItemViewModel() {
            MainCollection = GetStashEntries().OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<ItemEntry> GetStashEntries() {
            var goldEntries = new List<ItemEntry>();
            var stashEntries = LogDbManager.GetLogEntriesByType("stash").Where(entry => entry.ItemID != 0).ToList();

            List<Item> items = GuildWars2API.ItemAPI.GetItem(stashEntries.Select(entry => entry.ItemID));
            stashEntries.ForEach(entry => { goldEntries.Add(Reflection.CopyFrom(new ItemEntry() { Item = items.Find(item => item.ID == entry.ItemID) }, entry)); });
            return goldEntries;
        }
    }
}