using Dropbox.Api;
using Dropbox.Api.Files;
using GuildWars2Guild.Classes.Logger;
using System;
using System.IO;
using System.Threading.Tasks;

using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes.IO
{
    public static class DropBoxManager
    {
        public static async Task<bool> Download(string destinationFilePath, string sourceFilePath) {
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

        public static async Task<bool> Upload(string destinationFilePath, string sourceFilePath) {
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
    }
}
