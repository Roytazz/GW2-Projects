using GuildWars2API.Model.Guild;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GuildWars2Guild.Classes
{
    public class LogManager //: DbManager<LogEntry, GuildLogTable>        //LINQDbManager<LogEntry, GuildLogTableEntry>
    {
        private static void AddLog(LogEntry logs) {
            //Insert(logs);
            throw new NotImplementedException();
        }

        private static void AddLog(IEnumerable<LogEntry> logs) {
            //Insert(logs);
            throw new NotImplementedException();
        }

        public static void AddUniqueLog(IEnumerable<LogEntry> logs) {
            /*var existingIds = SelectColumn(log => log.ID).Distinct().ToList();
            var newLogs = GetUniqueEntries(logs, existingIds);
            if(newLogs.Count() > 0) {
                Insert(newLogs);
            }*/
            throw new NotImplementedException();
        }

        public static IEnumerable<LogEntry> GetLogs() {
            /*var entries = Select().ToList();
            var result = new List<LogEntry>();

            foreach(var entry in entries) {
                result.Add(entry);
            }
            return result;*/
            throw new NotImplementedException();
        }

        public static IEnumerable<LogEntry> GetLogs(string type) {
            //return Select(entry => entry.Type.Equals(type));
            //throw new NotImplementedException();
            return new List<LogEntry>();
        }

        public static IEnumerable<LogEntry> GetLogs(params string[] types) {
            //return Select(entry => types.Contains(entry.Type.ToString()));
            //throw new NotImplementedException();
            return new List<LogEntry>();
        }

        private static IEnumerable<LogEntry> GetUniqueEntries(IEnumerable<LogEntry> logs, IEnumerable<int> availableIDs) {
            /*if(logs == null || availableIDs == null)
                return null;

            var newLogs = logs.Where(log => !availableIDs.Any(dbLog => dbLog == log.ID));

            DisplayStashLogInfo(logs, newLogs);
            return newLogs.ToList();*/
            throw new NotImplementedException();
        }

        private static void DisplayStashLogInfo(IEnumerable<LogEntry> logs, IEnumerable<LogEntry> newLogs) {
            var totalStashEvents = logs.Where(log => log.Type.Equals("stash")).Count();
            var newStashEvents = newLogs.Where(log => log.Type.Equals("stash")).Count();
            Console.WriteLine(string.Format("Total Stash events retrieved: {0}", totalStashEvents));//, LogType.Info);
            Console.WriteLine(string.Format("New Stash events retrieved: {0}", newStashEvents));//, LogType.Info);
            Console.WriteLine(string.Format("Status is: {0}", (totalStashEvents > newStashEvents ? "Good" : "Bad")));//, LogType.Info);
        }
    }
}
