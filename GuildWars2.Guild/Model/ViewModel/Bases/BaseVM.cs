using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GuildWars2.Guild.Model.ViewModel.Bases
{
    abstract class BaseVM : INotifyPropertyChanged
    {
        public virtual ICollectionView MainCollectionView { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
