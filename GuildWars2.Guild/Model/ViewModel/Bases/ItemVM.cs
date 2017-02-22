using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Items;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Utility.Providers;

namespace GuildWars2Guild.Model.ViewModel.Bases
{
    abstract class ItemVM : FilterVM<ItemEntry>
    {
        public List<ItemEntry> MainCollection { get; set; }

        #region Selected Item

        private ItemEntry _selectedRow;

        public ItemEntry SelectedRow
        {
            get
            {
                if(_selectedRow == null) {
                    if(MainCollection?.Count > 0) {
                        return MainCollection[0];
                    }
                    else {
                        return new ItemEntry();
                    }
                }
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
                NotifyPropertyChanged(nameof(SelectedRow));
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

            if(CheckDate && item?.Time != null)
                result = IsBetweenDates(item.Time, StartDate, EndDate);

            if(CheckItemCount && ItemCount?.Length > 0 && result) {
                int itemCount;
                if (int.TryParse(ItemCount, out itemCount))
                    result = IsBiggerAmount(item.Count, int.Parse(ItemCount));
            }

            if(CheckKeyword && result)
                result = ContainsKeyword(KeywordValue, item?.User) || ContainsKeyword(KeywordValue, item?.Operation.ToString()) || ContainsKeyword(KeywordValue, item?.Item?.Name);

            return result;
        }

        #endregion Filter

        public ItemVM(params string[] types) {
            MainCollection = GetStashEntries(types).OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<ItemEntry> GetStashEntries(params string[] types) {
            var goldEntries = new List<ItemEntry>();
            var stashEntries = LogManager.GetLogs(types).Where(entry => entry.ItemID != 0).ToList();

            var itemIDs = stashEntries.Select(entry => entry.ItemID).ToList();

            List<Item> items = ResourceProvider.Instance.GetResource<Item>(itemIDs);
            List<ItemListing> listings = ResourceProvider.Instance.GetResource<ItemListing>(itemIDs);
            if(items == null || listings == null)
                return goldEntries;

            foreach(var entry in stashEntries) {
                var itemEntry = new ItemEntry() {
                                    Item = items.Find(item => item.ID == entry.ItemID),
                                    Listing = listings.Find(item => item.ItemID == entry.ItemID)
                                };
                goldEntries.Add(Reflection.CopyClass(itemEntry, entry));
            }
            return goldEntries;
        }
    }
}
