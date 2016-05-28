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

        private static async void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            Logger.LogManager.LogMessage("Update Started", false);
            await RefreshDbAsync();
            Logger.LogManager.LogMessage("Update Finished", false);
        }

        public static bool RefreshDb() {
            bool result = false;
            var task = Task.Run(async () => { result = await RefreshDbAsync(); });
            task.Wait();
            return result;
        }

        public static async Task<bool> RefreshDbAsync() {
            bool downloaded = await FileManager.DownloadDatabaseAsync();
            AddNewLogs();
            bool uploaded = await FileManager.UploadDatabaseAsync();

            return downloaded && uploaded;
        }

        public static bool DownloadDb() {
            bool result = false;
            var task = Task.Run(async () => { result = await DownloadDbAsync(); });
            task.Wait();
            return result;
        }

        public static async Task<bool> DownloadDbAsync() {
            return await FileManager.DownloadDatabaseAsync();
        }

        public static bool UploadDb() {
            bool result = false;
            var task = Task.Run(async () => { result = await UploadDbAsync(); });
            task.Wait();
            return result;
        }

        public static async Task<bool> UploadDbAsync() {
            return await FileManager.UploadDatabaseAsync();
        }

        public static void AddNewLogs() {
            var apikey = Properties.Settings.Default.ApiKey;
            if(apikey?.Length > 0) {
                var results = GuildWars2API.GuildAPI.GetGuildLogByName("Frostgorge Champ Train", Properties.Settings.Default.ApiKey);
                DBManager.AddLog(results);
            }
        }
    }
}