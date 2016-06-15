using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GuildWars2Guild.Model.ViewModel.Bases
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ICollectionView MainCollectionView { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
