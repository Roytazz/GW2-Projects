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
    public class GW2DataContext : DbContext {

        //TODO Write API-like access point for the database

        #region Tables
        public DbSet<User> User { get; set; }

        public DbSet<Key> Key { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CategoryValue> CategoryValue { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<WalletEntry> Wallet { get; set; }

        public DbSet<Skin> Skin { get; set; }

        public DbSet<Dye> Dye { get; set; }

        public DbSet<Mini> Mini { get; set; }
        #endregion Tables

        public GW2DataContext() : base() { }

        public GW2DataContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema(DbGlobals.SchemaName);

            builder.Entity<Dye>().HasKey(table => new { table.UserID, table.DyeID });
            builder.Entity<Mini>().HasKey(table => new { table.UserID, table.MiniID });
            builder.Entity<Skin>().HasKey(table => new { table.UserID, table.SkinID });

            builder.Entity<Key>().HasKey(table => new { table.UserID, table.APIKey });
            builder.Entity<User>().HasKey(table => new { table.ID, table.AccountName });

            builder.Entity<Category>().HasData(
                new Category { ID = 1, Type = CategoryType.Characters },
                new Category { ID = 2, Type = CategoryType.Bank },
                new Category { ID = 3, Type = CategoryType.GuildBank },
                new Category { ID = 4, Type = CategoryType.MaterialStorage },
                new Category { ID = 5, Type = CategoryType.SharedInventory },
                new Category { ID = 6, Type = CategoryType.Skins },
                new Category { ID = 7, Type = CategoryType.Dyes },
                new Category { ID = 8, Type = CategoryType.Minis }
            );

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

    internal static class DbGlobals {
        public const string SchemaName = "GuildWars2.Data";
    }

    public class DataContextFactory : IDesignTimeDbContextFactory<GW2DataContext> {

        public GW2DataContext CreateDbContext() {
            return CreateDbContext(new string[] { string.Empty });
        }

        public GW2DataContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<GW2DataContext>();
            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=aspnet-{DbGlobals.SchemaName};Trusted_Connection=True;MultipleActiveResultSets=true");
            return new GW2DataContext(builder.Options);
        }
    }
}