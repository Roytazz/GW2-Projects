using GuildWars2DB.Classes;
using GuildWars2DB.Model.Tables;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace GuildWars2DB.Model
{
    public  abstract class LINQDbManager<T, TTable> : BaseDbManager where T : class, new() 
                                                                    where TTable : class, new()
    {
        protected static void Insert(T entity) {
            using(var db = new Gw2DatabaseDB()) {
                db.Insert(Reflection.CopyClass<TTable, T>(entity));
            }
        }

        protected static void Insert(IEnumerable<T> entities) {
            using(var db = new Gw2DatabaseDB()) {
                foreach(var entity in entities) {
                    db.Insert(Reflection.CopyClass<TTable, T>(entity));
                }
            }
        }

        protected static void Delete(T entity) {
            using(var db = new Gw2DatabaseDB()) {
                db.Delete(Reflection.CopyClass<TTable, T>(entity));
            }
        }

        protected static void Delete(IEnumerable<T> entities) {
            using(var db = new Gw2DatabaseDB()) {
                foreach(var entity in entities) {
                    db.Delete(Reflection.CopyClass<TTable, T>(entity));
                }
            }
        }

        protected static void Clear() {
            using(var db = new Gw2DatabaseDB()) {
                db.GetTable<TTable>().Delete();
            }
        }

        protected static IEnumerable<T> Select() {
            using(var db = new Gw2DatabaseDB()) {
                return Reflection.CopyClass<T, TTable>(db.GetTable<TTable>());
            }
        }

        protected static IEnumerable<T> Select(Expression<Func<TTable, bool>> predicate) {
            using(var db = new Gw2DatabaseDB()) {
                return Reflection.CopyClass<T, TTable>(db.GetTable<TTable>().Where(predicate.Compile()));
            }
        }

        protected static IEnumerable<TResult> SelectColumn<TResult>(Expression<Func<TTable, TResult>> predicate) {
            using(var db = new Gw2DatabaseDB()) {
                return db.GetTable<TTable>().Select(predicate.Compile());
            }
        }
    }
}
