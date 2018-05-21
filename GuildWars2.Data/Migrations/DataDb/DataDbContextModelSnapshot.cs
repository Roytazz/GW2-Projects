﻿// <auto-generated />
using GuildWars2.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuildWars2.Data.Migrations.DataDb
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("GuildWars2.GW2Data")
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildWars2.API.Model.Items.Item", b =>
                {
                    b.Property<int>("KeyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChatLink");

                    b.Property<int>("DefaultSkin");

                    b.Property<string>("Description");

                    b.Property<string>("Details");

                    b.Property<string>("Flags");

                    b.Property<string>("GameTypes");

                    b.Property<int>("ID");

                    b.Property<string>("Icon");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Rarity");

                    b.Property<string>("Restrictions");

                    b.Property<int>("Type");

                    b.Property<int>("VendorValue");

                    b.HasKey("KeyID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Data.ItemSellable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Blacklisted");

                    b.Property<int>("ItemID");

                    b.Property<bool>("Sellable");

                    b.HasKey("ID");

                    b.ToTable("ItemSellable");
                });
#pragma warning restore 612, 618
        }
    }
}
