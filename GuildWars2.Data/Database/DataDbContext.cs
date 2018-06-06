using GuildWars2.API.Model;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Model.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.Data.Database
{
    internal class DataDbContext : DbContext
    {
        private const string SCHEMA_NAME = "GuildWars2.GW2Data";

        public DbSet<Item> Item { get; set; }

        public DbSet<ItemSellable> ItemSellable { get; set; }

        public DataDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema(SCHEMA_NAME);

            builder.Entity<Item>().Property<int>("KeyID");
            builder.Entity<Item>().HasKey("KeyID");
            builder.Entity<Item>().Ignore(x => x.Price);
            builder.Entity<Item>().Property(e => e.Details).HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<ItemDetails>(x)
            );
            builder.Entity<Item>().Property(e => e.Restrictions).HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<ItemRestriction>>(x)
            );
            builder.Entity<Item>().Property(e => e.GameTypes).HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<GameType>>(x)
            );
            builder.Entity<Item>().Property(e => e.Flags).HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<ItemFlag>>(x)
            );

            base.OnModelCreating(builder);
        }
    }
}
