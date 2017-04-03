using System;
using System.IO;
using System.Text;

namespace GuildWars2.Guild.Classes.IO
{
    class IOManager
    {
        private static object lockObj = new object();

        public static void WriteToLog(params string[] lines) {
            lock(lockObj) {
                using(FileStream fs = new FileStream(FileManager.GetFullLogPath(), FileMode.Append)) {
                    foreach(string line in lines) {
                        byte[] result = Encoding.ASCII.GetBytes(line + Environment.NewLine);
                        fs.Write(result, 0, result.Length);
                    }
                }
            }
        }
    }
}
