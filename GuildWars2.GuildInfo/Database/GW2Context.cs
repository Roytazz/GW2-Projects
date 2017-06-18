using GuildWars2.API.Model.Guild;
using System.Data.Entity;

namespace GuildWars2.GuildInfo.Database
{
    internal class GW2Context : DbContext
    {
        public DbSet<LogEntry> Logs { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<LogEntry>().HasKey(log => log.ID);
            modelBuilder.Entity<Member>().HasKey(member => member.Name);
            base.OnModelCreating(modelBuilder);
        }
    }
}
