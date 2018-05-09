using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildWars2.Data.Database
{
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.HasDefaultSchema(schema: DbGlobals.SchemaName);
            base.OnModelCreating(modelBuilder);
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