using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Data.Database
{
    internal class UserDbContext : DbContext
    {
        internal const string SCHEMA_NAME = "GuildWars2.UserData";

        #region Tables
        public DbSet<User> User { get; set; }

        public DbSet<Account> Account { get; set; }

        public DbSet<Key> Key { get; set; }

        public DbSet<CategoryValue> CategoryValue { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<WalletEntry> Wallet { get; set; }

        public DbSet<Model.Skin> Skin { get; set; }

        public DbSet<Dye> Dye { get; set; }

        public DbSet<Mini> Mini { get; set; }
        #endregion Tables

        public UserDbContext() : base() { }

        public UserDbContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema(SCHEMA_NAME);

            builder.Entity<Dye>().HasKey(x => new { x.AccountID, x.DyeID });
            builder.Entity<Mini>().HasKey(x => new { x.AccountID, x.MiniID });
            builder.Entity<Skin>().HasKey(x => new { x.AccountID, x.SkinID });
            builder.Entity<Key>().HasKey(x => new { x.UserID, x.APIKey, x.AccountID });

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
}