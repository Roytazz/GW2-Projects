using GuildWars2APIPlaceHolder.Model.Account;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder
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
            return Builder.AddPointer("achievements")
                .Request<List<AccountAchievement>>(apiKey);
        }

        public static List<BankEntity> Bank(string apiKey)
        {
            return Builder.AddPointer("bank")
                .Request<List<BankEntity>>(apiKey);
        }

        public static List<int> Dyes(string apiKey)
        {
            return Builder.AddPointer("dyes")
                .Request<List<int>>(apiKey);
        }

        public static List<AccountFinisher> Finishers(string apiKey)   
        {
            return Builder.AddPointer("finishers")
                .Request<List<AccountFinisher>>(apiKey);
        }

        public static List<Inventory> SharedInventory(string apiKey)
        {
            return Builder.AddPointer("inventory")
                .Request<List<Inventory>>(apiKey);
        }

        public static List<Material> MaterialStorage(string apiKey)
        {
            return Builder.AddPointer("materials")
                .Request<List<Material>>(apiKey);
        }

        public static List<int> Minis(string apiKey)    
        {
            return Builder.AddPointer("minis")
                .Request<List<int>>(apiKey);
        }

        public static List<int> Skins(string apiKey)    
        {
            return Builder.AddPointer("skins")
                .Request<List<int>>(apiKey);
        }

        public static List<int> Titles(string apiKey)   
        {
            return Builder.AddPointer("titles")
                .Request<List<int>>(apiKey);
        }

        public static List<WalletEntry> Wallet(string apiKey)   
        {
            return Builder.AddPointer("wallet")
                .Request<List<WalletEntry>>(apiKey);
        }
        
        public static List<int> Recipes(string apiKey)  
        {
            return Builder.AddPointer("recipes")
                .Request<List<int>>(apiKey);
        }

        public static List<int> Outfits(string apiKey)   
        {
            return Builder.AddPointer("outfits")
                .Request<List<int>>(apiKey);
        }

        public static List<AccountMastery> Masteries(string apiKey)   
        {
            return Builder.AddPointer("masteries")
                .Request<List<AccountMastery>>(apiKey);
        }
    }
}
