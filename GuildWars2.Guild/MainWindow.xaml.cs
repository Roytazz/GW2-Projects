using GuildWars2Guild.Classes;
using MahApps.Metro.Controls;
using System.Windows;

namespace GuildWars2Guild
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            UpdateManager.UpdateDatabase();
            UpdateManager.InitializeTimer();
            InitializeComponent();
        }
        
        private void Settings_Click(object sender, RoutedEventArgs e) {
            SettingsFlyout.IsOpen = true;
        }
    }
}
