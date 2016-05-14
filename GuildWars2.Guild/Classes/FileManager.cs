using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2Guild.Classes
{
    class FileManager
    {
        public static string DB_PATH = "/GuildWars2Guild.Classes.GW2DBContext.mdf";
        public static string DB_LOG_PATH = "/GuildWars2Guild.Classes.GW2DBContext_log.ldf";

        public static string GetConnectionString() {
            AppDomain.CurrentDomain.SetData("DataDirectory", GetExecutingAssembly());
            return @"Data Source=(localdb)\mssqllocaldb;AttachDbFileName=|DataDirectory|\GuildWars2Guild.Classes.GW2DBContext.mdf;";
        }

        public static bool IsDatabasePresent() {
            return File.Exists(GetExecutingAssembly() + DB_PATH);
        }

        public static void UploadDatabase() {
            var task = Task.Run(async () => { await Upload(DB_PATH, GetFullDataBasePath()); });
            task.Wait();
        }

        public static void DownloadDatabase() {
            var task = Task.Run(async () => { await Download(GetFullDataBasePath(), DB_PATH); });
            task.Wait();
        }

        public static void UploadDatabaseAsync() {
            Task.Run(() => Upload(DB_PATH, GetFullDataBasePath()));
        }

        public static void DownloadDatabaseAsync() {
            Task.Run(() => Download(GetFullDataBasePath(), DB_PATH));
        }

        private static async Task Download(string destinationFilePath, string sourceFilePath) {
            RemoveLogFile();
            using(DropboxClient dbx = new DropboxClient(Properties.Settings.Default.DropBoxKey)) {
                using(var response = await dbx.Files.DownloadAsync(sourceFilePath)) {
                    byte[] result = await response.GetContentAsByteArrayAsync();
                    File.WriteAllBytes(destinationFilePath, result);
                }
            }
        }

        private static async Task Upload(string destinationFilePath, string sourceFilePath) {
            using(DropboxClient dbx = new DropboxClient(Properties.Settings.Default.DropBoxKey)) {
                using(var mem = new MemoryStream(File.ReadAllBytes(sourceFilePath))) {
                    var updated = await dbx.Files.UploadAsync(destinationFilePath, WriteMode.Overwrite.Instance, body: mem);
                    Console.WriteLine("Saved to: {0}", destinationFilePath);
                }
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
        
        private static void RemoveLogFile() {
            if(File.Exists(GetExecutingAssembly() + DB_LOG_PATH)) {
                File.Delete(GetExecutingAssembly() + DB_LOG_PATH);
            }
        }
    }
}