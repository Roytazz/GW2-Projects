using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildWars2.Data.Database
{
    internal class DataContextFactory : IDesignTimeDbContextFactory<DataDbContext>
    {
        public DataDbContext CreateDbContext() {
            return CreateDbContext(new string[] { string.Empty });
        }

        public DataDbContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<DataDbContext>();
            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=aspnet-{DataDbContext.SCHEMA_NAME};Trusted_Connection=True;MultipleActiveResultSets=true");
            return new DataDbContext(builder.Options);
        }
    }

    internal class UserContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {

        public UserDbContext CreateDbContext() {
            return CreateDbContext(new string[] { string.Empty });
        }

        public UserDbContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<UserDbContext>();
            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=aspnet-{UserDbContext.SCHEMA_NAME};Trusted_Connection=True;MultipleActiveResultSets=true");
            return new UserDbContext(builder.Options);
        }
    }
}
