using System;
using System.Threading.Tasks;
using System.Timers;

namespace GuildWars2Guild.Classes
{
    public static class UpdateManager
    {
        private static Timer _timer;
        private static double TICK_TIME = 1000 * 60 * 60;   //60min

        public static void InitializeTimer() {
            _timer = new Timer(TICK_TIME);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            Console.WriteLine("UPDATE");
            UpdateDatabaseAsync();
        }

        public static void UpdateDatabase() {
            Update();
        }

        public static void UpdateDatabaseAsync() {
            Task.Run(() => Update());
        }

        private static void Update() {
            if(!FileManager.IsDatabasePresent()) {
                FileManager.DownloadDatabaseAsync();
                return;
            }
            else {
                FileManager.DownloadDatabaseAsync();
                UpdateDB();
                FileManager.UploadDatabaseAsync();
            }
        }

        private static void UpdateDB() {
            var apikey = Properties.Settings.Default.ApiKey;
            if(apikey?.Length > 0) {
                var results = GuildWars2API.GuildAPI.GetGuildLogByName("Frostgorge Champ Train", Properties.Settings.Default.ApiKey);
                DBManager.AddLog(results);
            }
        }
    }
}
