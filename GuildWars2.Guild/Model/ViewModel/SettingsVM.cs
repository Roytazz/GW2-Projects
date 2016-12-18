using GuildWars2Guild.Classes.MVVM;
using GuildWars2Guild.Model.ViewModel.Bases;
using System.Windows;
using System.Windows.Input;

namespace GuildWars2Guild.Model.ViewModel
{
    class SettingsVM : BaseVM
    {
        private string _apiKey;
        private string _guildName;
        private string _dropboxKey;
        
        public string GuildName
        {
            get { return _guildName; }
            set
            {
                if(!_guildName.Equals(value)) {
                    _guildName = value;
                    NotifyPropertyChanged(nameof(GuildName));
                    Properties.Settings.Default.GuildName = value;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public string ApiKey
        {
            get { return _apiKey; }
            set {
                if(!_apiKey.Equals(value)) {
                    _apiKey = value;
                    NotifyPropertyChanged(nameof(ApiKey));
                    Properties.Settings.Default.ApiKey = value;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public string DropBoxKey
        {
            get { return _dropboxKey; }
            set
            {
                if(!_dropboxKey.Equals(value)) {
                    _dropboxKey = value;
                    NotifyPropertyChanged(nameof(DropBoxKey));
                    Properties.Settings.Default.DropBoxKey = value;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public virtual ICommand Refresh => (new RelayCommand((parameter) => {
            if(parameter is Window) {
                var mainWindow = (parameter as MainWindow); 
                mainWindow.Reload();
            }
        }));

        public SettingsVM() {
            _apiKey = Properties.Settings.Default.ApiKey;
            _guildName = Properties.Settings.Default.GuildName;
            _dropboxKey = Properties.Settings.Default.DropBoxKey;
        }
    }
}
