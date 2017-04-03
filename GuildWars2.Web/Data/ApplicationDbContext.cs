using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GuildWars2.Web.Models;
using GuildWars2.API.Model.Items;
using System.Collections.Generic;
using System;

namespace GuildWars2.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<ApiKeyInfo> ApiKeyInfo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ItemDetails>().Property<int>("ID").IsRequired();
            builder.Entity<ItemDetails>().HasKey("ID");
            builder.Entity<Item>().HasKey(c => c.ID);

            builder.Entity<Item>()
                .Ignore(c => c.Flags)
                .Ignore(c => c.GameTypes)
                .Ignore(c => c.Restrictions);

            builder.Entity<ItemDetails>()
                .Ignore(c => c.InfusionSlots)
                .Ignore(c => c.StatChoices)
                .Ignore(c => c.InfixUpgrade)
                .Ignore(c => c.Flags)
                .Ignore(c => c.InfusionUpgradeFlags)
                .Ignore(c => c.Bonuses);
        }
    }
}