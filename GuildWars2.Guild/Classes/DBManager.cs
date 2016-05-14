using GuildWars2API.Model.Guild;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace GuildWars2Guild.Classes
{
    class DBManager
    {
        public static void AddLog(LogEntry log) {
            using(var db = new GW2DBContext()) {
                if(!db.Log.Any(dbLog => dbLog.LogID == log.LogID)) {
                    db.Log.Add(Reflection.CopyFrom(new DBLogEntry(), log));
                    db.SaveChanges();
                }
            }
        }

        public static void AddLog(List<LogEntry> logs) {
            if(logs == null)
                return;

            using(var db = new GW2DBContext()) {
                var availableIDs = db.Log.Select(log => log.LogID).Distinct().ToList();
                var newLogs = GetUniqueEntries(logs, availableIDs);
                if(newLogs?.Count > 0) {
                    db.Log.AddRange(newLogs);
                    db.SaveChanges();
                }
            }
        }

        public static List<LogEntry> GetLogEntries() {
            using(var db = new GW2DBContext()) {
                return db.Log.ToList().Cast<LogEntry>().ToList();
            }
        }

        public static List<LogEntry> GetLogEntries(string type) {
            using(var db = new GW2DBContext()) {
                return db.Log.Where(entry => entry.Type.Equals(type)).ToList().Cast<LogEntry>().ToList();
            }
        }

        public static void ClearLogs() {
            using(var db = new GW2DBContext()) {
                var items = db.Log.ToList();
                db.Log.RemoveRange(items);
                db.SaveChanges();
            }
        }

        private static List<DBLogEntry> GetUniqueEntries(List<LogEntry> logs, IEnumerable<int> availableIDs) {
            if(logs == null || availableIDs == null)
                return null;
            
            var newLogs = logs.Where(log => !availableIDs.Any(dbLog => dbLog == log.LogID));

            DisplayStashLogInfo(logs, newLogs);

            var dbLogs = new List<DBLogEntry>();
            foreach(var log in newLogs) {
                dbLogs.Add(Reflection.CopyFrom(new DBLogEntry(), log));
                
            }
            return dbLogs;
        }
        
        private static void DisplayStashLogInfo(List<LogEntry> logs, IEnumerable<LogEntry> newLogs) {
            var totalStashEvents = logs.Where(log => log.Type.Equals("stash")).Count();
            var newStashEvents = newLogs.Where(log => log.Type.Equals("stash")).Count();
            Console.WriteLine(string.Format("Total Stash events retrieved: {0}", totalStashEvents));
            Console.WriteLine(string.Format("New Stash events retrieved: {0}", newStashEvents));
            Console.WriteLine(string.Format("Status is: {0}", (totalStashEvents > newStashEvents ? "Good" : "Bad")));
        }
    }

    class DBLogEntry : LogEntry
    {
        public DBLogEntry() { }

        [Key]
        public int ID { get; set; }
    }

    class GW2DBContext : DbContext
    {
        public GW2DBContext() : base(FileManager.GetConnectionString()) {}

        public DbSet<DBLogEntry> Log { get; set; }
    }
}
