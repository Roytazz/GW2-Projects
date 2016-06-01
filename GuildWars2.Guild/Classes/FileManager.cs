using Dropbox.Api;
using Dropbox.Api.Files;
using GuildWars2Guild.Classes.Logger;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes
{
    class FileManager
    {
        private static string DB_PATH = "/GuildWars2Guild.Classes.GW2DBContext.mdf";
        private static string DB_LOG_PATH = "/GuildWars2Guild.Classes.GW2DBContext_log.ldf";

        private static string LOG_PATH = "/GuildWars2Guild.log";

        private static object lockObj = new object();

        #region Database

        public static bool IsDatabasePresent() {
            return File.Exists(GetExecutingAssembly() + DB_PATH);
        }

        public static Task<bool> UploadDatabaseAsync() {
            Thread.Sleep(1000);     //Yes I know its ugly, but it needs to be here
            return Upload(DB_PATH, GetFullDataBasePath());
        }

        public static Task<bool> DownloadDatabaseAsync() {
            return Download(GetFullDataBasePath(), DB_PATH);
        }

        private static string GetFullDataBasePath() {
            return string.Format("{0}{1}", GetExecutingAssembly(), DB_PATH);
        }

        private static bool RemoveDBLogFile() {
            if(!File.Exists(GetExecutingAssembly() + DB_LOG_PATH)) {
                return true;
            }
            else {
                try {
                    LogMessage<ConsoleLogger>("Deleting the DB log file", LogType.Info);
                    File.Delete(GetExecutingAssembly() + DB_LOG_PATH);
                    return true;
                }
                catch(Exception ex) {
                    LogException(ex, "Failed to delete the DB log file");
                    return false;
                }
            }
        }

        #endregion Database

        #region Dropbox
        private static async Task<bool> Download(string destinationFilePath, string sourceFilePath) {
            if(!RemoveDBLogFile())
                return false;

            try {
                using(DropboxClient dbx = GetDropboxClient()) {
                    using(var response = await dbx.Files.DownloadAsync(sourceFilePath)) {
                        LogMessage<ConsoleLogger>("Downloading the DB", LogType.Info);
                        byte[] result = await response.GetContentAsByteArrayAsync();
                        File.WriteAllBytes(destinationFilePath, result);
                        LogMessage<ConsoleLogger>("Done with downloading the DB", LogType.Info);
                        return true;
                    }
                }
            }
            catch(Exception ex) {
                LogException(ex, "Failed to download the DB file");
                return false;
            }
        }

        private static async Task<bool> Upload(string destinationFilePath, string sourceFilePath) {
            try {
                using(DropboxClient dbx = GetDropboxClient()) {
                    using(var mem = new MemoryStream(File.ReadAllBytes(sourceFilePath))) {
                        LogMessage<ConsoleLogger>("Upload the DB", LogType.Info);
                        await dbx.Files.UploadAsync(destinationFilePath, WriteMode.Overwrite.Instance, body: mem);
                        LogMessage<ConsoleLogger>("Done with uploading the DB", LogType.Info);
                        return true;
                    }
                }
            }
            catch(Exception ex) {
                LogException(ex, "Failed to upload the DB file");
                return false;
            }
        }

        private static DropboxClient GetDropboxClient() {
            return new DropboxClient(Properties.Settings.Default.DropBoxKey);          
        }

        #endregion Dropbox

        #region Logfile

        public static void WriteToLog(params string[] lines) {
            lock(lockObj) {
                using(FileStream fs = new FileStream(GetFullLogPath(), FileMode.Append)) {
                    foreach(string line in lines) {
                        byte[] result = Encoding.ASCII.GetBytes(line + Environment.NewLine);
                        fs.Write(result, 0, result.Length);
                    }
                }
            }
        }

        private static string GetFullLogPath() {
            return string.Format("{0}{1}", GetExecutingAssembly(), LOG_PATH);
        }

        #endregion Logfile

        public static string GetExecutingAssembly() {
            var executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(executable);
        }
    }
}