using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace GuildWars2.Worker
{
    internal class DiffConsoleHelper<T>
    {
        private static readonly string FILE_LOCATION = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "preview.htm");

        private T _obj1;
        private T _obj2;

        public DiffConsoleHelper(T obj1, T obj2) {
            _obj1 = obj1;
            _obj2 = obj2;
        }

        public bool DiffObject(bool waitForUser) {
            var left = JToken.FromObject(_obj1);
            var right = JToken.FromObject(_obj2);
            
            JToken patch = new JsonDiffPatch().Diff(left, right);

            if (patch != null) {
                if (!waitForUser)
                    return true;

                Console.WriteLine(patch.ToString());
                Console.WriteLine();
                Console.WriteLine("Type 'Y' to replace item. Type 'V' to show changes.");
                HandleUserResponse();
            }
            return false;
        }

        private bool HandleUserResponse() {
            var userResponse = Console.ReadKey();
            switch (userResponse.Key) {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.V:
                    ShowChanges();
                    return HandleUserResponse();
                default:
                    return false;
            }
        }

        private void ShowChanges() {
            BuildHtmlPage();

            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            p.StartInfo.Arguments = Uri.EscapeDataString(FILE_LOCATION);
            p.Start();
        }

        private void BuildHtmlPage() {
            var html = new StringBuilder();
            html.Append("<html><head><style>");
            html.Append("table{border:1pxsolid#d9d9d9;}     td{border:1pxsolid#d9d9d9;padding:3px;}     ins{background-color:#cfc;text-decoration:inherit;}     del{color:#999;background-color:#FEC8C8;}     ins.mod{background-color:#FFE1AC;}");
            html.Append("</style></head><body><div>");
            html.Append(new HtmlDiff.HtmlDiff(JsonConvert.SerializeObject(_obj1), JsonConvert.SerializeObject(_obj2)).Build());
            html.Append("</div></body></html>");

            using (FileStream fs = new FileStream(FILE_LOCATION, FileMode.Create)) {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8)) {
                    w.WriteLine(html);
                }
            }
        }
    }
}
