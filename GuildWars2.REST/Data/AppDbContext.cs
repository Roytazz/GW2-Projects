using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GuildWars2.REST.Database;
using GuildWars2.REST.Model;

namespace GuildWars2.REST.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<ApiKey> ApiKey { get; set; }

        public DbSet<UserItemStackDifference> ItemDifference { get; set; }
        public DbSet<UserCurrencyDifference> CurrencyDifference { get; set; }

        public DbSet<UserItemTrend> ItemTrend { get; set; }
        public DbSet<UserCurrencyTrend> CurrencyTrend { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
