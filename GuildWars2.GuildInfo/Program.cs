using GuildWars2.API;
using GuildWars2.API.Model.Guild;
using GuildWars2.GuildInfo.Database;
using GuildWars2.GuildInfo.Models;
using GuildWars2.GuildInfo.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace GuildWars2.GuildInfo
{
    class Program
    {
        private static SheetManager _manager = new SheetManager();
        private static Timer _timer = new Timer(new TimeSpan(6, 0, 0).TotalMilliseconds);

        private static string GUILD_ID = "E2C92543-0EAC-E411-AA11-AC162DAAE275";
        private static string API_KEY = "89100791-2D70-1C49-9F14-CDD1FCB8A9F0C701F31A-B88C-460C-B6D7-3ADD8748837D";

        static void Main(string[] args) {
            _timer.Elapsed += (sender, e) => Update();
            Update();
            while (true) {
                var results = Console.ReadLine();
                switch (results.ToLower()) {
                    case "exit":
                    return;

                    case "":
                    return;

                    case "update":
                        Update();
                    break;

                    case "members":
                        Squires();
                    break;

                    case "roster":
                        Roster();
                    break;

                    default:
                    break;
                }
            }
        }

        private static void Update() {
            //DBManager.AddUniqueLogs(GuildAPI.Logs(GUILD_ID, API_KEY).GetAwaiter().GetResult());
            DBManager.AddUniqueOnProp(GuildAPI.Logs(GUILD_ID, API_KEY).GetAwaiter().GetResult(), log => log.Time, (x, y) => x.Time > y.Time);
            DBManager.AddUnique(GuildAPI.Members(GUILD_ID, API_KEY).GetAwaiter().GetResult(), (x, y) => x.Name.Equals(y.Name));
            Squires();
            Roster();
        }

        private static void Roster() {
            var rawRosterEvents = DBManager.GetEntity<LogEntry>(x =>
                                        x.Type == LogType.Joined ||
                                        x.Type == LogType.Kick ||
                                        x.Type == LogType.RankChange ||
                                        x.Type == LogType.Invited ||
                                        x.Type == LogType.InviteDeclined);

            var rosterEvents = new List<RankLogEntry>();
            rawRosterEvents.ForEach(x => rosterEvents.Add(new RankLogEntry { Entry = x }));
            _manager.Write(rosterEvents, SheetType.Roster);
        }

        private static void Squires() {
            var rawRosterEvents = DBManager.GetEntity<Member>(x => x.RankName.Equals("Squire"));
            rawRosterEvents.OrderByDescending(x => x.Joined);
            var rosterEvents = new List<SquireLogEntry>();
            rawRosterEvents.ForEach(x => rosterEvents.Add(new SquireLogEntry { Member = x }));
            _manager.Write(rosterEvents, SheetType.Squires);
        }
    }
}