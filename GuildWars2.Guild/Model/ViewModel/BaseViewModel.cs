using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GuildWars2Guild.Model.ViewModel
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ICollectionView MainCollectionView { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
