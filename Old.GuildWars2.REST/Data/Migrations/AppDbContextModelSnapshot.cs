using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GuildWars2.REST.Data;
using GuildWars2.API.Model;
using GuildWars2.API.Model.Items;

namespace GuildWars2.REST.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildWars2.API.Model.Commerce.ItemListingAggregated", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BuysID");

                    b.Property<int?>("SellsID");

                    b.Property<bool>("Whitelisted");

                    b.HasKey("ItemID");

                    b.HasIndex("BuysID");

                    b.HasIndex("SellsID");

                    b.ToTable("AggregatedListing");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Commerce.Listing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Listings");

                    b.Property<int>("Quantity");

                    b.Property<int>("UnitPrice");

                    b.HasKey("ID");

                    b.ToTable("Listing");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.Infix", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BuffID");

                    b.HasKey("ID");

                    b.HasIndex("BuffID");

                    b.ToTable("Infix");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.InfixAttribute", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attribute");

                    b.Property<int?>("InfixID");

                    b.Property<int>("Modifier");

                    b.HasKey("ID");

                    b.HasIndex("InfixID");

                    b.ToTable("InfixAttribute");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.InfixBuff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SkillID");

                    b.HasKey("ID");

                    b.ToTable("InfixBuff");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.Infusion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemID");

                    b.HasKey("ID");

                    b.ToTable("Infusion");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChatLink");

                    b.Property<int>("DefaultSkin");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailsID");

                    b.Property<string>("Icon");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Rarity");

                    b.Property<int>("Type");

                    b.Property<int>("VendorValue");

                    b.HasKey("ID");

                    b.HasIndex("DetailsID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.ItemDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplyCount");

                    b.Property<int>("Charges");

                    b.Property<int>("ColorID");

                    b.Property<int>("DamageType");

                    b.Property<int>("Defense");

                    b.Property<string>("Description");

                    b.Property<int>("DurationMS");

                    b.Property<int?>("InfixUpgradeID");

                    b.Property<int>("MaxPower");

                    b.Property<int>("MinPower");

                    b.Property<int>("MiniPetID");

                    b.Property<string>("Name");

                    b.Property<bool>("NoSellOrSort");

                    b.Property<int>("RecipeID");

                    b.Property<string>("SecondarySuffixItemID");

                    b.Property<int>("Size");

                    b.Property<string>("Suffix");

                    b.Property<int>("SuffixItemID");

                    b.Property<string>("Type");

                    b.Property<int>("UnlockType");

                    b.Property<int>("WeightClass");

                    b.HasKey("ID");

                    b.HasIndex("InfixUpgradeID");

                    b.ToTable("ItemDetails");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChatLink");

                    b.Property<int>("MinRating");

                    b.Property<int>("OutputItemCount");

                    b.Property<int>("OutputItemID");

                    b.Property<int>("OutputUpgradeID");

                    b.Property<int>("TimeToCraft");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.RecipeGuildIngredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<int>("ItemID");

                    b.Property<int?>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeGuildIngredient");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.RecipeIngredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<int>("ItemID");

                    b.Property<int?>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("GuildWars2.REST.Model.ApiKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Key");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApiKey");
                });

            modelBuilder.Entity("GuildWars2.REST.Model.UserCurrencyDifference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<int>("Count");

                    b.Property<int>("CurrencyID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Difference");

                    b.Property<bool>("ManualEntry");

                    b.HasKey("ID");

                    b.ToTable("CurrencyDifference");
                });

            modelBuilder.Entity("GuildWars2.REST.Model.UserCurrencyTrend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<int>("Count");

                    b.Property<int>("CurrencyID");

                    b.Property<DateTime>("Date");

                    b.HasKey("ID");

                    b.ToTable("CurrencyTrend");
                });

            modelBuilder.Entity("GuildWars2.REST.Model.UserItemStackDifference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<int>("Count");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Difference");

                    b.Property<int>("ItemID");

                    b.Property<bool>("ManualEntry");

                    b.Property<int>("SkinID");

                    b.Property<int>("StatID");

                    b.HasKey("ID");

                    b.ToTable("ItemDifference");
                });

            modelBuilder.Entity("GuildWars2.REST.Model.UserItemTrend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<int>("Count");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ItemID");

                    b.HasKey("ID");

                    b.ToTable("ItemTrend");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Commerce.ItemListingAggregated", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Commerce.Listing", "Buys")
                        .WithMany()
                        .HasForeignKey("BuysID");

                    b.HasOne("GuildWars2.API.Model.Commerce.Listing", "Sells")
                        .WithMany()
                        .HasForeignKey("SellsID");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.Infix", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Items.InfixBuff", "Buff")
                        .WithMany()
                        .HasForeignKey("BuffID");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.InfixAttribute", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Items.Infix")
                        .WithMany("Attributes")
                        .HasForeignKey("InfixID");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.Item", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Items.ItemDetails", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsID");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.ItemDetails", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Items.Infix", "InfixUpgrade")
                        .WithMany()
                        .HasForeignKey("InfixUpgradeID");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.RecipeGuildIngredient", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Items.Recipe")
                        .WithMany("GuildIngredients")
                        .HasForeignKey("RecipeID");
                });

            modelBuilder.Entity("GuildWars2.API.Model.Items.RecipeIngredient", b =>
                {
                    b.HasOne("GuildWars2.API.Model.Items.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID");
                });

            modelBuilder.Entity("GuildWars2.REST.Model.ApiKey", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
