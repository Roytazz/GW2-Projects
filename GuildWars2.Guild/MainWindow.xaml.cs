using MahApps.Metro.Controls;
using System.Windows;

namespace GuildWars2Guild
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            InitializeComponent();
        }
        
        private void Settings_Click(object sender, RoutedEventArgs e) {
            this.SettingsFlyout.IsOpen = true;
        }

        public void Reload() {
            this.MainContent = new Controls.MainWindowControl();
        }
        //TODO Guild stash inventory/treasury requirements/Guild upgrades
    }
}