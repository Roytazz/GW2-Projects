using GuildWars2DB;
using GuildWars2Guild.Classes.IO;
using GuildWars2Guild.Classes.Logger;
using System.Threading.Tasks;
using System.Timers;

namespace GuildWars2Guild.Classes
{
    public static class UpdateManager
    {
        #region Timer

        private static Timer _timer;
        private static double TICK_TIME = 1000 * 60 * 60;   //60min

        public static void InitializeTimer() {
            _timer = new Timer(TICK_TIME);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private static async void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            LogManager.LogMessage<ConsoleLogger>("Update Started", LogType.Info, true);
            await RefreshDbAsync();
            LogManager.LogMessage<ConsoleLogger>("Update Finished", LogType.Info, true);
        }

        #endregion Timer

        public static bool RefreshDb() {
            bool result = false;
            var task = Task.Run(async () => { result = await RefreshDbAsync(); });
            task.Wait();
            return result;
        }

        public static async Task<bool> RefreshDbAsync() {
            bool downloaded = await FileManager.DownloadDatabaseAsync();
            if(downloaded) {
                AddNewLogs();
                return await FileManager.UploadDatabaseAsync();
            }

            return false;
        }

        #region Download & Upload

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

        #endregion Download & Upload

        internal static void AddNewLogs() {
            var apiKey = Properties.Settings.Default.ApiKey;
            if(apiKey?.Length > 0) {
                var results = GuildWars2API.GuildAPI.GetGuildLogByName("Frostgorge Champ Train", apiKey);
                LogDbManager.AddUniqueLog(results);
            }
        }
    }
}