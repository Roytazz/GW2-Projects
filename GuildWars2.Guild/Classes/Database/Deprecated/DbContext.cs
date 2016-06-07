using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.IO;
using GuildWars2Guild.Classes.Logger;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

using static GuildWars2Guild.Classes.Logger.LogManager;

namespace GuildWars2Guild.Classes.Database.Deprecated
{
    internal class GW2DbContext : DbContext
    {
        private static string ConnectionString
        {
            get {
                AppDomain.CurrentDomain.SetData("DataDirectory", FileManager.GetExecutingAssembly());
                return @"Data Source=(localdb)\mssqllocaldb;AttachDbFileName=|DataDirectory|\GuildWars2Guild.Classes.GW2DBContext.mdf;Pooling=false;";
            }
        }

        public GW2DbContext() : base(ConnectionString) { }

        public DbSet<DBLogEntry> Log { get; set; }

        public override int SaveChanges() {
            try {
                return base.SaveChanges();
            }
            catch(DbEntityValidationException ex) {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " Validation errors found: ", fullErrorMessage);
                LogException<FileLogger>(ex, exceptionMessage);

                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                return -1;
            }
        }
    }

    internal class DBLogEntry : LogEntry, IDbEntity
    {
        public DBLogEntry() { }

        [Key]
        public int ID { get; set; }
    }
}
