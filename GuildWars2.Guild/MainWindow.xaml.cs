using MahApps.Metro.Controls;
using System.Windows;

namespace GuildWars2Guild
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow() {
            //DBManager.ClearLogs();
            /*var apikey = "EA50C40A-C88C-7D48-90EC-7D46C2C505C8F8E798A6-FD91-4580-A7A4-6A64B2826245";
            var results = GuildWars2API.GuildAPI.GetGuildLogByName("Frostgorge Champ Train", apikey);
            DBManager.AddLog(results);*/
            InitializeComponent();
        }

        private void Settings_Click(object sender, RoutedEventArgs e) {
            SettingsFlyout.IsOpen = true;
        }
    }
}
