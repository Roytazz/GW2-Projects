using GuildWars2.Guild.Classes.MVVM;
using System;
using System.Windows.Input;

namespace GuildWars2.Guild.Model.ViewModel.Bases
{
    abstract class FilterVM<T> : BaseVM
    {
        protected abstract bool OnFilter(object value);

        public virtual ICommand ApplyFilter => new CommandHandler(() => {
            MainCollectionView?.Refresh();
        });

        protected bool IsBetweenDates(DateTime value, DateTime startDate, DateTime endDate) => value.Date >= startDate.Date && value.Date <= endDate.Date;

        protected bool IsBiggerAmount(int value, int threshold) => value >= threshold;

        protected bool ContainsKeyword(string keyWord, string value) {
            if(string.IsNullOrEmpty(keyWord) || string.IsNullOrEmpty(value))
                return false;

            return value.ToLower().Contains(keyWord.ToLower());
        }
    }
}
