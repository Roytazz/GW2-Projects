using GuildWars2.API;
using GuildWars2.API.Model.Guild;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GuildWars2.Guild.Classes
{
    public sealed class LogManager //: DbManager<LogEntry, GuildLogTable>        //LINQDbManager<LogEntry, GuildLogTableEntry>
    {
        private static object lockObj = new object();
        private static volatile LogManager _instance;

        private List<LogEntry> _logs;
        private List<LogEntry> Logs {
            get {
                if (_logs == null) {
                    var guilddetails = GuildAPI.DetailsByName(Properties.Settings.Default.GuildName).GetAwaiter().GetResult();
                    _logs = GuildAPI.Logs(guilddetails.ID, Properties.Settings.Default.ApiKey).GetAwaiter().GetResult();
                }
                if (_logs == null)
                    return new List<LogEntry>();

                return _logs;
            }
        }

        public static LogManager Instance
        {
            get {
                if (_instance == null) {
                    lock (lockObj) {
                        if (_instance == null)
                            _instance = new LogManager();
                    }
                }
                return _instance;
            }
        }

        private void AddLog(LogEntry logs) {
            //Insert(logs);
            throw new NotImplementedException();
        }

        private void AddLog(IEnumerable<LogEntry> logs) {
            //Insert(logs);
            throw new NotImplementedException();
        }

        public void AddUniqueLog(IEnumerable<LogEntry> logs) {
            /*var existingIds = SelectColumn(log => log.ID).Distinct().ToList();
            var newLogs = GetUniqueEntries(logs, existingIds);
            if(newLogs.Count() > 0) {
                Insert(newLogs);
            }*/
            throw new NotImplementedException();
        }

        public IEnumerable<LogEntry> GetLogs(LogType type) {
            return Logs.Where(entry => entry.Type.Equals(type));
        }

        public IEnumerable<LogEntry> GetLogs(params LogType[] types) {
            return Logs.Where(entry => types.Contains(entry.Type));
        }

        private IEnumerable<LogEntry> GetUniqueEntries(IEnumerable<LogEntry> logs, IEnumerable<int> availableIDs) {
            if(logs == null || availableIDs == null)
                return null;

            var newLogs = logs.Where(log => !availableIDs.Any(dbLog => dbLog == log.ID));

            DisplayStashLogInfo(logs, newLogs);
            return newLogs.ToList();
        }

        private void DisplayStashLogInfo(IEnumerable<LogEntry> logs, IEnumerable<LogEntry> newLogs) {
            var totalStashEvents = logs.Where(log => log.Type.Equals("stash")).Count();
            var newStashEvents = newLogs.Where(log => log.Type.Equals("stash")).Count();
            Console.WriteLine(string.Format("Total Stash events retrieved: {0}", totalStashEvents));//, LogType.Info);
            Console.WriteLine(string.Format("New Stash events retrieved: {0}", newStashEvents));//, LogType.Info);
            Console.WriteLine(string.Format("Status is: {0}", (totalStashEvents > newStashEvents ? "Good" : "Bad")));//, LogType.Info);
        }
    }
}
