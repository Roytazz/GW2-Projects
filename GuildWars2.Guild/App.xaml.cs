using GuildWars2.Guild.Classes;
using System.Windows;

namespace GuildWars2.Guild
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            foreach(var flag in e.Args) {
                if(flag.Contains("update")) {
                    UpdateManager.RefreshDb();
                    Shutdown();
                }
            }
            base.OnStartup(e);
        }
    }
}
