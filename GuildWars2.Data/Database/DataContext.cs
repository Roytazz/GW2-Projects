using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Data.Database
{
    public class DataContext : DbContext {

        #region Tables
        public DbSet<Category> Category { get; set; }

        public DbSet<CategoryValue> CategoryValue { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<WalletEntry> Wallet { get; set; }

        public DbSet<Skin> Skin { get; set; }

        public DbSet<Dye> Dye { get; set; }
        #endregion Tables

        public DataContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema(schema: DbGlobals.SchemaName);

            builder.Entity<Dye>().HasKey(table => new { table.UserID, table.ItemID });
            builder.Entity<Skin>().HasKey(table => new { table.UserID, table.SkinID });

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) {
            SetDates();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken)) {
            SetDates();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetDates() {
            var date = DateTime.UtcNow;
            var entries = base.ChangeTracker.Entries().Where(x => x.Entity is DateEntry && x.State == EntityState.Added);
            foreach (var entry in entries) {
                (entry.Entity as DateEntry).Date = date;
            }
        }
    }

    public static class DbGlobals {
        public const string SchemaName = "GuildWars2.Data";
    }

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext> {
        public DataContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=config;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new DataContext(builder.Options);
        }
    }
}