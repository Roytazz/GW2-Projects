using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Logger;
using System.Collections.Generic;
using System.Linq;
using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes.Database.Deprecated
{
    internal class LogDbManager : BaseDbManager<DBLogEntry>    
    {
        public static void AddLog(LogEntry log) {
            AddEntity(ConvertLog(log));
        }

        public static void AddLog(IEnumerable<LogEntry> logs) {
            if(logs == null)
                return;

            var availableIDs = GetColumn(log => log.LogID).Distinct().ToList();
            var newLogs = GetUniqueEntries(logs, availableIDs);
            if(newLogs.Count() > 0) {
                AddEntity(ConvertLog(newLogs));
            }
        }
        
        public static IEnumerable<LogEntry> GetLogEntriesByType(params string[] types) {
            var entities = GetEntities(entry => types.Contains(entry.Type));
            return entities.Cast<LogEntry>();
        }

        public static IEnumerable<LogEntry> GetLogs() {
            return GetEntities();
        }

        private static IEnumerable<LogEntry> GetUniqueEntries(IEnumerable<LogEntry> logs, IEnumerable<int> availableIDs) {
            if(logs == null || availableIDs == null)
                return null;
            
            var newLogs = logs.Where(log => !availableIDs.Any(dbLog => dbLog == log.LogID));

            DisplayStashLogInfo(logs, newLogs);
            return newLogs.ToList();
        }

        private static DBLogEntry ConvertLog(LogEntry log) {
            return Reflection.CopyClass(new DBLogEntry(), log);
        }

        private static IEnumerable<DBLogEntry> ConvertLog(IEnumerable<LogEntry> logs) {
            var newLogs = new List<DBLogEntry>();
            foreach(var log in logs) {
                newLogs.Add(ConvertLog(log));
            }
            return newLogs;
        }
        
        private static void DisplayStashLogInfo(IEnumerable<LogEntry> logs, IEnumerable<LogEntry> newLogs) {
            var totalStashEvents = logs.Where(log => log.Type.Equals("stash")).Count();
            var newStashEvents = newLogs.Where(log => log.Type.Equals("stash")).Count();
            LogMessage<ConsoleLogger>(string.Format("Total Stash events retrieved: {0}", totalStashEvents), LogType.Info);
            LogMessage<ConsoleLogger>(string.Format("New Stash events retrieved: {0}", newStashEvents), LogType.Info);
            LogMessage<ConsoleLogger>(string.Format("Status is: {0}", (totalStashEvents > newStashEvents ? "Good" : "Bad")), LogType.Info);
        }
    }
}