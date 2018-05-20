using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Data.Database
{
    internal class GW2DataContext : DbContext {
        
        internal const string SCHEMA_NAME = "GuildWars2.Data";

        #region Tables
        public DbSet<User> User { get; set; }

        public DbSet<Key> Key { get; set; }

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
            builder.HasDefaultSchema(SCHEMA_NAME);

            builder.Entity<Dye>().HasKey(x => new { x.UserID, x.DyeID });
            builder.Entity<Mini>().HasKey(x => new { x.UserID, x.MiniID });
            builder.Entity<Skin>().HasKey(x => new { x.UserID, x.SkinID });
            builder.Entity<Key>().HasKey(x => new { x.UserID, x.APIKey });

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

    internal class ContextFactory : IDesignTimeDbContextFactory<GW2DataContext> {

        public GW2DataContext CreateDbContext() {
            return CreateDbContext(new string[] { string.Empty });
        }

        public GW2DataContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<GW2DataContext>();
            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=aspnet-{GW2DataContext.SCHEMA_NAME};Trusted_Connection=True;MultipleActiveResultSets=true");
            return new GW2DataContext(builder.Options);
        }
    }
}