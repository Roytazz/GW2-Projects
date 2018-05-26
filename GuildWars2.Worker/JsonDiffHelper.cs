using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace GuildWars2.Worker
{
    internal static class JsonDiffConsoleHelper
    {
        public static bool DiffObject<T>(T obj1, T obj2, bool waitForUser = true) {
            var jdp = new JsonDiffPatch();

            var leftString = JsonConvert.SerializeObject(obj1);
            var rightString = JsonConvert.SerializeObject(obj2);

            var left = JToken.FromObject(obj1);
            var right = JToken.FromObject(obj2);
            JToken patch = jdp.Diff(left, right);

            if (patch != null) {
                if (!waitForUser)
                    return true;

                Console.WriteLine(patch.ToString());
                Console.WriteLine();
                Console.WriteLine("Type 'Y' to replace current item.");
                var userResponse = Console.ReadKey();
                if (userResponse.Key == ConsoleKey.Y)
                    return true;
            }
            return false;
        }
    }
}
