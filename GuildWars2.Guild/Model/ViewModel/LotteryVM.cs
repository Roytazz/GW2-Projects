using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.MVVM;
using GuildWars2Guild.Model.ViewModel.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace GuildWars2Guild.Model.ViewModel
{
    class LotteryVM : FilterVM<GoldEntry>
    {
        public string GoldValue { get; set; }
        public string ExcludedMembers { get; set; }
        public List<GuildWeek> GuildWeeks { get; set; }
        public List<GoldEntry> MainCollection { get; set; }
        public List<MemberTicket> MemberTickets { get { return GetUniqueAccumulatedTickets(); } }

        private List<string> ExcludedMembersList {
            get {
                var list = new List<string>();
                if(!string.IsNullOrEmpty(ExcludedMembers))
                    list.AddRange(ExcludedMembers.Split(';').ToList());

                return list;
            }
        }

        public LotteryVM() {
            GoldValue = 5.ToString();
            MainCollection = GetStashEntries().OrderByDescending(entry => entry.Time).ToList();

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            while(date.DayOfWeek != DayOfWeek.Monday) {
                date = date.AddDays(1);
            }

            GuildWeeks = new List<GuildWeek> {
                new GuildWeek { Title = "Week 1", Parent = this, StartDate = date, EndDate = date.AddDays(5) },
                new GuildWeek { Title = "Week 2", Parent = this, StartDate = date.AddDays(7), EndDate = date.AddDays(12) },
                new GuildWeek { Title = "Week 3", Parent = this, StartDate = date.AddDays(14), EndDate = date.AddDays(19) },
                new GuildWeek { Title = "Week 4", Parent = this, StartDate = date.AddDays(21), EndDate = date.AddDays(26) }
            };
        }

        private List<GoldEntry> GetStashEntries() {
            var goldEntries = new List<GoldEntry>();

            var stashEntries = LogManager.Instance.GetLogs(LogType.Stash).Where(entry => entry.Coins > 0).ToList();
            foreach(var entry in stashEntries) {
                goldEntries.Add(Reflection.CopyClass<GoldEntry, LogEntry>(entry));
            }

            return goldEntries;
        }

        internal List<GoldEntry> GetUniqueAccumulatedLogs(DateTime startDate, DateTime endDate) {
            var entries = MainCollection.Where(entry => IsBetweenDates(entry.Time, startDate, endDate));
            var uniqueNames = entries.Select(entry => entry.User).Distinct();

            List<GoldEntry> accumulatedEntries = new List<GoldEntry>();
            foreach(string name in uniqueNames) {
                if(ExcludedMembersList.Contains(name))
                    continue;

                var deposits = entries.Where(entry => entry.User.Equals(name)
                                                && entry.Operation.Equals("deposit"))
                                        .Sum(entry => entry.Coins);

                var withdraws = entries.Where(entry => entry.User.Equals(name)
                                                && entry.Operation.Equals("withdraw"))
                                            .Sum(entry => entry.Coins);

                var amount = deposits - withdraws;
                if(amount == 0)     //No entries between the dates
                    continue;

                if(GoldValue == null || GoldValue.Length <= 0 || new ItemPrice(amount).CompareTo(new ItemPrice(int.Parse(GoldValue) * 10000)) >= 0)
                    accumulatedEntries.Add(new GoldEntry { User = name, Coins = deposits - withdraws });
            }
            return accumulatedEntries;
        }

        internal List<MemberTicket> GetUniqueAccumulatedTickets() {
            var goldEntries = new List<GoldEntry>();
            foreach(var guildWeek in GuildWeeks) {
                goldEntries.AddRange(guildWeek.GoldEntries);
            }

            var users = goldEntries.Select(entry => entry.User).Distinct();
            var memberTickets = new List<MemberTicket>();
            foreach(var user in users) {
                var count = goldEntries.Count(entry => entry.User.Equals(user));
                memberTickets.Add(new MemberTicket { User = user, Tickets = count });
            }
            return memberTickets;
        }

        public override ICommand ApplyFilter => new CommandHandler(() => {
            foreach(var guildWeek in GuildWeeks) {
                guildWeek.TriggerUpdate();
            }
            NotifyPropertyChanged(nameof(MemberTickets));
        });

        public ICommand Export => new CommandHandler(() => {
            string result = "";
            foreach(var memberTicket in MemberTickets) {
                for(int i = 0; i < memberTicket.Tickets; i++) {
                    result += memberTicket.User + ";" + Environment.NewLine;
                }
            }
            Clipboard.SetText(result);
        });

        protected override bool OnFilter(object value) {
            throw new NotImplementedException();
        }
    }

    class GuildWeek : BaseVM
    {
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;

        public DateTime StartDate {
            get {
                return _startDate;
            }
            set {
                if(!_startDate.Equals(value)) {
                    _startDate = value;
                    NotifyPropertyChanged(nameof(StartDate));
                    NotifyPropertyChanged(nameof(MainCollectionView));
                }
            }
        }
        public DateTime EndDate
        {
            get {
                return _endDate;
            }
            set {
                if(!_endDate.Equals(value)) {
                    _endDate = value;
                    NotifyPropertyChanged(nameof(EndDate));
                    NotifyPropertyChanged(nameof(MainCollectionView));
                }
            }
        }

        public string Title { get; set; }
        public LotteryVM Parent { get; set; }
        internal List<GoldEntry> GoldEntries { get { return Parent.GetUniqueAccumulatedLogs(StartDate, EndDate); } }
        public override ICollectionView MainCollectionView
        {
            get {
                return CollectionViewSource.GetDefaultView(GoldEntries);
            }
        }

        public ICommand Export => new CommandHandler(() => {
            string result = "";
            for(int i = 0; i < GoldEntries.Count; i++) {
                result += (i + 1) + " => " + GoldEntries[i].User + ";" + Environment.NewLine;
            }
            Clipboard.SetText(result);
        });

        public void TriggerUpdate() {
            NotifyPropertyChanged(nameof(MainCollectionView));
        }
    }
    
    public class MemberTicket
    {
        public string User { get; set; }
        public int Tickets { get; set; }
    }
}
