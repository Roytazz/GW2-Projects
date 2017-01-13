using GuildWars2API.Model.Account;
using System.Collections.Generic;

namespace GuildWars2API
{
    public static class AccountAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("account"); } }

        public static Account Account(string apiKey)
        {
            return Builder.Request<Account>(apiKey);
        }

        public static List<AccountAchievement> AccountAchievements(string apiKey) 
        {
            return Builder.AddDirective("achievements")
                .Request<List<AccountAchievement>>(apiKey);
        }

        public static List<BankEntity> Bank(string apiKey)
        {
            return Builder.AddDirective("bank")
                .Request<List<BankEntity>>(apiKey);
        }

        public static List<int> Dyes(string apiKey)
        {
            return Builder.AddDirective("dyes")
                .Request<List<int>>(apiKey);
        }

        public static List<AccountFinisher> Finishers(string apiKey)   
        {
            return Builder.AddDirective("finishers")
                .Request<List<AccountFinisher>>(apiKey);
        }

        public static List<Inventory> SharedInventory(string apiKey)
        {
            return Builder.AddDirective("inventory")
                .Request<List<Inventory>>(apiKey);
        }

        public static List<Material> MaterialStorage(string apiKey)
        {
            return Builder.AddDirective("materials")
                .Request<List<Material>>(apiKey);
        }

        public static List<int> Minis(string apiKey)    
        {
            return Builder.AddDirective("minis")
                .Request<List<int>>(apiKey);
        }

        public static List<int> Skins(string apiKey)    
        {
            return Builder.AddDirective("skins")
                .Request<List<int>>(apiKey);
        }

        public static List<int> Titles(string apiKey)   
        {
            return Builder.AddDirective("titles")
                .Request<List<int>>(apiKey);
        }

        public static List<WalletEntry> Wallet(string apiKey)   
        {
            return Builder.AddDirective("wallet")
                .Request<List<WalletEntry>>(apiKey);
        }
        
        public static List<int> Recipes(string apiKey)  
        {
            return Builder.AddDirective("recipes")
                .Request<List<int>>(apiKey);
        }

        public static List<int> Outfits(string apiKey)   
        {
            return Builder.AddDirective("outfits")
                .Request<List<int>>(apiKey);
        }

        public static List<AccountMastery> Masteries(string apiKey)   
        {
            return Builder.AddDirective("masteries")
                .Request<List<AccountMastery>>(apiKey);
        }
    }
}
