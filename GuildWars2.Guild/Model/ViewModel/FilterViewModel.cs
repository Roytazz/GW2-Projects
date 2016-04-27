using GuildWars2Guild.Classes.MVVM;
using System.ComponentModel;
using System.Windows.Input;

namespace GuildWars2Guild.Model.ViewModel
{
    abstract class FilterViewModel<T> : ViewModelBase<T>
    {
        public ICollectionView MainCollectionView { get; set; }

        protected abstract bool OnFilter(object value);

        public ICommand ApplyFilter => (new CommandHandler(() => {
            if(MainCollectionView != null) {
                MainCollectionView.Refresh();
            }
        }));
    }
}
