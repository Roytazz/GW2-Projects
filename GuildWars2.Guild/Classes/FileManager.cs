using Dropbox.Api;
using Dropbox.Api.Files;
using GuildWars2Guild.Classes.Logger;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes
{
    class FileManager
    {
        public static string DB_PATH = "/GuildWars2Guild.Classes.GW2DBContext.mdf";
        public static string DB_LOG_PATH = "/GuildWars2Guild.Classes.GW2DBContext_log.ldf";

        public static string GetConnectionString() {
            AppDomain.CurrentDomain.SetData("DataDirectory", GetExecutingAssembly());
            return @"Data Source=(localdb)\mssqllocaldb;AttachDbFileName=|DataDirectory|\GuildWars2Guild.Classes.GW2DBContext.mdf;Pooling=false;";
        }

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

        private static async Task<bool> Download(string destinationFilePath, string sourceFilePath) {
            if(!RemoveLogFile())
                return false;

            try {
                using(DropboxClient dbx = new DropboxClient(Properties.Settings.Default.DropBoxKey)) {
                    using(var response = await dbx.Files.DownloadAsync(sourceFilePath)) {
                        LogMessage("Downloading the DB", false);
                        byte[] result = await response.GetContentAsByteArrayAsync();
                        File.WriteAllBytes(destinationFilePath, result);
                        LogMessage("Done with downloading the DB", false);
                        return true;
                    }
                }
            }
            catch(Exception ex) {
                LogException(ex, "Failed to download the DB file", false);
                return false;
            }
        }

        private static async Task<bool> Upload(string destinationFilePath, string sourceFilePath) {
            try {
                using(DropboxClient dbx = new DropboxClient(Properties.Settings.Default.DropBoxKey)) {
                    using(var mem = new MemoryStream(File.ReadAllBytes(sourceFilePath))) {
                        LogMessage("Upload the DB", false);
                        await dbx.Files.UploadAsync(destinationFilePath, WriteMode.Overwrite.Instance, body: mem);
                        LogMessage("Done with uploading the DB", false);
                        return true;
                    }
                }
            }
            catch(Exception ex) {
                LogException(ex, "Failed to upload the DB file", false);
                return false;
            }
        }

        private static DropboxClient GetClient() {
            return new DropboxClient(Properties.Settings.Default.DropBoxKey);
        }

        private static string GetExecutingAssembly() {
            var executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(executable);
        }

        private static string GetFullDataBasePath() {
            return string.Format("{0}{1}", GetExecutingAssembly(), DB_PATH);
        }

        private static bool RemoveLogFile() {
            if(File.Exists(GetExecutingAssembly() + DB_LOG_PATH)) {
                try {
                    LogMessage("Deleting the DB log file", false);      
                    File.Delete(GetExecutingAssembly() + DB_LOG_PATH);
                    return true;
                }
                catch(Exception ex) { LogException(ex, "Failed to delete the DB log file", false); }
            }
            return false;
        }
    }
}