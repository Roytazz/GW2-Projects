using GuildWars2Guild.Classes;
using System.Windows;

namespace GuildWars2Guild
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            foreach(var flag in e.Args) {
                if(flag.Contains("update")) {
                    UpdateManager.UpdateDatabase();
                    Shutdown();
                }
            }
            base.OnStartup(e);
        }
    }
}
