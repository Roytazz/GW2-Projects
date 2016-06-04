using GuildWars2API.Model.Value;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
using GuildWars2Guild.Classes.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace GuildWars2Guild.Model.ViewModel
{
    class LotteryViewModel : FilterViewModel<GoldEntry>
    {
        private Random _random;
        private List<GoldEntry> _stashEntries;

        public List<GoldEntry> MainCollection { get; set; }

        #region Picker

        public string ExcludedMembers { get; set; }

        public GoldEntry Winner { get; set; }

        public ICommand PickWinner => (new CommandHandler(() => {
            var collection = GetEligibleWinners();
            Winner = collection[_random.Next(collection.Count)];
            NotifyPropertyChanged("Winner");
        }));

        private List<GoldEntry> GetEligibleWinners() {
            var collection = new List<GoldEntry>(MainCollection);
            if(ExcludedMembers != null && ExcludedMembers.Length > 0) {
                foreach(string name in ExcludedMembers.Split(';')) {
                    collection.Add(new GoldEntry { User = name.Trim() });
                }
            }
            return collection;
        }

        #endregion Picker

        #region Filter

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GoldValue { get; set; }

        protected override bool OnFilter(object value) => true;

        public override ICommand ApplyFilter => (new CommandHandler(() => {
            MainCollection = GetUniqueAccumulatedEntries();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            NotifyPropertyChanged("MainCollectionView");
        }));

        #endregion Filter

        public ICommand Export => (new CommandHandler(() => {
            string result = "";
            foreach(GoldEntry entry in GetEligibleWinners()) {
                result += entry.User + ";" + Environment.NewLine;
            }
            Clipboard.SetText(result);
        }));

        public LotteryViewModel() {
            var today = DateTime.Now;
            StartDate = new DateTime(today.Year, today.Month, 1);
            EndDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            _random = new Random();
            _stashEntries = GetStashEntries();
            
            MainCollection = GetUniqueAccumulatedEntries().OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<GoldEntry> GetUniqueAccumulatedEntries() {
            var uniqueNames = _stashEntries.Select(entry => entry.User).Distinct();

            List<GoldEntry> accumulatedEntries = new List<GoldEntry>();
            foreach(string name in uniqueNames) {
                var deposits = _stashEntries.Where(entry => entry.User.Equals(name) 
                                                && entry.Operation.Equals("deposit") 
                                                && IsBetweenDates(entry.Time, StartDate, EndDate))
                                        .Sum(entry => entry.Coins);

                var withdraws = _stashEntries.Where(entry => entry.User.Equals(name) 
                                                && entry.Operation.Equals("withdraw") 
                                                && IsBetweenDates(entry.Time, StartDate, EndDate))
                                            .Sum(entry => entry.Coins);

                var amount = deposits - withdraws;
                if(amount == 0)     //No entries between the dates
                    continue;

                if(GoldValue == null || GoldValue.Length <= 0 || IsBiggerAmount(amount, new ItemPrice(int.Parse(GoldValue) * 10000).Gold))      
                    accumulatedEntries.Add(new GoldEntry { User = name, Coins = deposits - withdraws });
            }

            return accumulatedEntries;
        }

        private List<GoldEntry> GetStashEntries() {
            var goldEntries = new List<GoldEntry>();

            var stashEntries = LogDbManager.GetLogEntriesByType("stash").Where(entry => entry.Coins > 0).ToList();
            stashEntries.ForEach(entry => { goldEntries.Add(Reflection.CopyFrom(new GoldEntry(), entry)); });

            return goldEntries;
        }
    }
}
