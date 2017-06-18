using GuildWars2.API.Model.Guild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GuildWars2.GuildInfo.Database
{
    internal static class DBManager
    {
        internal static void AddUniqueLogs(IEnumerable<LogEntry> entities) {
            using (var db = new GW2Context()) {
                var lastEntity = db.Logs.OrderByDescending(log => log.Time).FirstOrDefault();
                if (lastEntity != null) {
                    entities = entities.Where(log => log.Time > lastEntity.Time);
                }
                Console.WriteLine($"New amount of entries since last update: {entities.Count()}");
                db.Logs.AddRange(entities);
                db.SaveChanges();
            }
        }

        internal static void AddEntity<T>(IEnumerable<T> entities) where T : class {
            using (var db = new GW2Context()) { 
                db.Set<T>().AddRange(entities);
                db.SaveChanges();
            }
        }

        internal static List<T> GetEntity<T>(Func<T, bool> predicate) where T : class {
            using (var db = new GW2Context()) {
                return db.Set<T>().Where(predicate).ToList();
            }
        }

        internal static void AddUniqueOnProp<T>(IEnumerable<T> entities, Func<T, object> sort, Func<T, T, bool> predicate) where T : class {
            using (var db = new GW2Context()) {
                var lastEntity = db.Set<T>().OrderByDescending(sort).FirstOrDefault();
                if (lastEntity != null) {
                    entities = entities.Where(entity => predicate(entity, lastEntity));
                }
                Console.WriteLine($"New amount of {typeof(T).Name} entries since last update: {entities.Count()}");
                if (entities.Count() == 0)
                    return;

                db.Set<T>().AddRange(entities);
                db.SaveChanges();
            }
        }

        internal static void AddUnique<T>(IEnumerable<T> entities, Func<T, T, bool> predicate) where T : class {
            using (var db = new GW2Context()) {
                var newEntities = new List<T>();
                var currentEntities = db.Set<T>().ToList();
                foreach (var entity in entities) {
                    if (!currentEntities.Any(t => predicate(t, entity)))
                        newEntities.Add(entity);
                }
                Console.WriteLine($"New amount of {typeof(T).Name} entries since last update: {newEntities.Count()}");
                db.Set<T>().AddRange(newEntities);
                db.SaveChanges();
            }
        }
    }
}