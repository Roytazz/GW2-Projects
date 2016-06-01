using GuildWars2Guild.Classes.MVVM;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace GuildWars2Guild.Model.ViewModel
{
    abstract class FilterViewModel<T> : ViewModelBase
    {
        public ICollectionView MainCollectionView { get; set; }

        protected abstract bool OnFilter(object value);

        public virtual ICommand ApplyFilter => (new CommandHandler(() => {
            MainCollectionView?.Refresh();
        }));

        protected bool IsBetweenDates(DateTime value, DateTime startDate, DateTime endDate) => value.Date >= startDate.Date && value.Date <= endDate.Date;

        protected bool IsBiggerAmount(int value, int threshold) => value >= threshold;

        protected bool ContainsKeyword(string keyWord, string value) => value.ToLower().Contains(keyWord.ToLower());
    }
}
