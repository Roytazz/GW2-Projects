﻿using GuildWars2API.Model.Value;
using GuildWars2Guild.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                result = IsBetweenDates(item.Time);

            if(CheckGold && GoldValue?.Length > 0 && result)
                result = IsBiggerAmount(item.Value.Gold);

            if(CheckKeyword && result)
                result = ContainsKeyword(item.User) || ContainsKeyword(item.Operation);

            return result;
        }

        private bool IsBetweenDates(DateTime value) => value >= StartDate && value <= EndDate;

        private bool IsBiggerAmount(int value) => value >= int.Parse(GoldValue);

        private bool ContainsKeyword(string value) => value.Contains(KeywordValue);

        #endregion Filter

        #region Member

        private GoldEntry _selectedRow;

        public GoldEntry SelectedRow
        {
            get { return _selectedRow; }
            set
            {
                _selectedRow = value;
                NotifyPropertyChanged("MemberTotal");
                NotifyPropertyChanged("GoldLogMember");
                NotifyPropertyChanged("SelectedMember");
            }
        }

        public string SelectedMember
        {
            get
            {
                if(SelectedRow != null) {
                    return SelectedRow.User;
                }
                return "Total";
            }
        }

        public ItemPrice MemberTotal
        {
            get
            {
                if(SelectedRow != null) {
                    return GetSubTotal(SelectedRow.User);
                }
                return null;
            }
        }

        public ObservableCollection<GoldEntry> GoldLogMember
        {
            get
            {
                if(MainCollection != null && SelectedRow != null) {
                    var results = new ObservableCollection<GoldEntry>(MainCollection.Where(entry => entry.User.Equals(SelectedRow.User)).ToList());
                    return results;
                }
                return new ObservableCollection<GoldEntry>();
            }
        }

        private ItemPrice GetSubTotal(string username) {
            if(MainCollection == null)
                return null;

            var goldEntries = MainCollection.Where(entry => entry.User.Equals(username));

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

        #endregion Member

        public StashGoldViewModel() {
            EndDate = DateTime.Now;
            MainCollection = GetStashEntries();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<GoldEntry> GetStashEntries() {
            var goldEntries = new List<GoldEntry>();

            var stashEntries = DBManager.GetLogEntries("stash").Where(entry => entry.Coins > 0).ToList();
            stashEntries.ForEach(entry => { goldEntries.Add(Refection.CopyFrom(new GoldEntry(), entry)); });

            return goldEntries;
        }
    }
}