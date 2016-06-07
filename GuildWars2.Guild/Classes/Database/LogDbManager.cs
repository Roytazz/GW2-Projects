﻿using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Database.Tables;
using GuildWars2Guild.Classes.Logger;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes.Database
{
    class LogDbManager : BaseDbManager<GuildLogTable, LogEntry>
    {
        private static void AddLog(LogEntry logs) {
            AddEntity(logs);
        }

        private static void AddLog(IEnumerable<LogEntry> logs) {
            AddEntity(logs);
        }

        public static void AddUniqueLog(IEnumerable<LogEntry> logs) {
            var existingIds = GetEntity().Select(log => log.LogID).Distinct().ToList();
            var newLogs = GetUniqueEntries(logs, existingIds);
            if(newLogs.Count() > 0) {
                AddEntity(newLogs);
            }
        }

        public static IEnumerable<LogEntry> GetLogs() {
            return GetEntity();
        }

        public static IEnumerable<LogEntry> GetLogs(string type) {
            return GetEntity().Where(entry => entry.Type.Equals(type));
        }

        public static IEnumerable<LogEntry> GetLogs(params string[] types) {
            return GetEntity().Where(entry => types.Contains(entry.Type));
        }

        private static IEnumerable<LogEntry> GetUniqueEntries(IEnumerable<LogEntry> logs, IEnumerable<int> availableIDs) {
            if(logs == null || availableIDs == null)
                return null;

            var newLogs = logs.Where(log => !availableIDs.Any(dbLog => dbLog == log.LogID));

            DisplayStashLogInfo(logs, newLogs);
            return newLogs.ToList();
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
