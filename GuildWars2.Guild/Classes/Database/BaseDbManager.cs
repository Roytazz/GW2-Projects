using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GuildWars2Guild.Classes.Database
{
    internal abstract class BaseDbManager<T> where T : class, IDbEntity, new()
    {
        public static void AddEntity(T entity) {
            using(var db = new GW2DbContext()) {
                AddEntity(entity, db);
            }
        }

        private static void AddEntity(T entity, GW2DbContext db) {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public static void AddUniqueEntity(T entity) {
            using(var db = new GW2DbContext()) {
                if(!db.Set<T>().Any(dbEntity => dbEntity.ID == entity.ID)) 
                    AddEntity(entity, db);
            }
        }

        public static void AddEntity(IEnumerable<T> entities) {
            if(entities == null || entities.Count() <= 0)
                return;

            using(var db = new GW2DbContext()) {
                db.Set<T>().AddRange(entities);
                db.SaveChanges();
            }
        }

        public static void ClearEntities() {
            using(var db = new GW2DbContext()) {
                var items = db.Set<T>().ToList();
                db.Set<T>().RemoveRange(items);
                db.SaveChanges();
            }
        }

        public static IEnumerable<T> GetEntities() {
            using(var db = new GW2DbContext()) {
                return db.Set<T>().ToList().Cast<T>().ToList();
            }
        }

        public static List<T> GetEntities(Expression<Func<T, bool>> predicate) {
            using(var db = new GW2DbContext()) {
                return db.Set<T>().Where(predicate.Compile()).Cast<T>().ToList();
            }
        }

        public static List<TResult> GetColumn<TResult>(Expression<Func<T, TResult>> predicate) {
            using(var db = new GW2DbContext()) {
                return db.Set<T>().Select(predicate.Compile()).ToList();
            }
        }
    }

    internal interface IDbEntity
    {
        int ID { get; set; }
    }
}
