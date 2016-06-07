using GuildWars2Guild.Classes.Logger;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes.IO
{
    public static class FileManager
    {
        #region Paths

        private static string DB_PATH = "/FGCT_DATABASE.sqlite";
        private static string LOG_PATH = "/FGCT_LOG.log";

        public static string GetExecutingAssembly() {
            var executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(executable);
        }

        private static bool IsDatabasePresent() {
            return File.Exists(GetExecutingAssembly() + DB_PATH);
        }

        public static string GetFullDataBasePath() {
            return string.Format("{0}{1}", GetExecutingAssembly(), DB_PATH);
        }

        public static string GetFullLogPath() {
            return string.Format("{0}{1}", GetExecutingAssembly(), LOG_PATH);
        }

        #endregion Paths

        public static Task<bool> UploadDatabaseAsync() {
            if(!IsDatabasePresent())
                return Task.FromResult(false);

            Thread.Sleep(1000);     //Yes I know its ugly, but it needs to be here
            return DropBoxManager.Upload(DB_PATH, GetFullDataBasePath());
        }

        public static Task<bool> DownloadDatabaseAsync() {
            return DropBoxManager.Download(GetFullDataBasePath(), DB_PATH);
        }
    }
}
