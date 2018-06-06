using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Old.GuildWars2.REST.Database;
using Old.GuildWars2.REST.Model;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.API.Model;

namespace Old.GuildWars2.REST.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ApiKey> ApiKey { get; set; }

        public DbSet<UserItemStackDifference> ItemDifference { get; set; }
        public DbSet<UserCurrencyDifference> CurrencyDifference { get; set; }

        public DbSet<UserItemTrend> ItemTrend { get; set; }
        public DbSet<UserCurrencyTrend> CurrencyTrend { get; set; }

        public DbSet<Item> Item { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<ItemListingAggregated> AggregatedListing { get; set; }

        //public DbSet<Infusion> Infusion { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            AddKey<Infix>(builder);
            AddKey<InfixAttribute>(builder);
            AddKey<InfixBuff>(builder);
            AddKey<Listing>(builder);
            AddKey<ItemDetails>(builder);
            AddKey<RecipeGuildIngredient>(builder);
            AddKey<RecipeIngredient>(builder);
            AddKey<Infusion>(builder);

            builder.Entity<Item>().HasKey("ID");
            builder.Entity<ItemListingAggregated>().HasKey(nameof(ItemListingAggregated.ItemID));

            builder.Entity<Item>().Ignore(x => x.Flags);
            builder.Entity<Item>().Ignore(x => x.GameTypes);
            builder.Entity<Item>().Ignore(x => x.Restrictions);
            builder.Ignore<ItemPrice>();

            builder.Entity<ItemDetails>().Ignore(x => x.InfusionSlots);
            builder.Entity<ItemDetails>().Ignore(x => x.InfusionUpgradeFlags);
            builder.Entity<ItemDetails>().Ignore(x => x.Flags);
            builder.Entity<ItemDetails>().Ignore(x => x.Bonuses);
            builder.Entity<ItemDetails>().Ignore(x => x.StatChoices);

            builder.Entity<Infusion>().Ignore(x => x.Flags);

            builder.Entity<Recipe>().Ignore(x => x.Disciplines);
            builder.Entity<Recipe>().Ignore(x => x.Flags);
        }

        private void AddKey<T>(ModelBuilder builder, string name = "ID") where T : class
        {
            builder.Entity<T>().Property<int>(name);
            builder.Entity<T>().HasKey(name);
        }
    }
}
