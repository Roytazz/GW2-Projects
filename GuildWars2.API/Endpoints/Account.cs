using GuildWars2.API.Model.Account;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class AccountAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("account"); } }

        public static Task<Account> Account(string apiKey)
        {
            return Builder.RequestAsync<Account>(apiKey);
        }

        #region Achievements
        public static Task<List<AccountAchievement>> AccountAchievements(string apiKey) 
        {
            return Builder.AddDirective("achievements")
                .RequestAsync<List<AccountAchievement>>(apiKey);
        }
        public static Task<AccountAchievement> AccountAchievements(int ID, string apiKey) {
            return Builder.AddDirective("achievements")
                .AddParam("id", ID.ToString())
                .RequestAsync<AccountAchievement>(apiKey);
        }
        public static Task<List<AccountAchievement>> AccountAchievements(List<int> IDs, string apiKey) {
            return Builder.AddDirective("achievements")
                .AddParam("ids", IDs)
                .RequestAsync<List<AccountAchievement>>(apiKey);
        }
        public static Task<List<AccountAchievement>> AccountAchievements(int pageCount, int page, string apiKey) {
            return Builder.AddDirective("achievements")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<AccountAchievement>>(apiKey);
        }
        #endregion Achievements

        public static Task<List<BankEntity>> Bank(string apiKey)
        {
            return Builder.AddDirective("bank")
                .RequestAsync<List<BankEntity>>(apiKey);
        }

        public static Task<List<int>> Dyes(string apiKey)
        {
            return Builder.AddDirective("dyes")
                .RequestAsync<List<int>>(apiKey);
        }

        public static Task<List<AccountFinisher>> Finishers(string apiKey)   
        {
            return Builder.AddDirective("finishers")
                .RequestAsync<List<AccountFinisher>>(apiKey);
        }

        public static Task<List<Inventory>> SharedInventory(string apiKey)
        {
            return Builder.AddDirective("inventory")
                .RequestAsync<List<Inventory>>(apiKey);
        }

        public static Task<List<Material>> MaterialStorage(string apiKey)
        {
            return Builder.AddDirective("materials")
                .RequestAsync<List<Material>>(apiKey);
        }

        public static Task<List<int>> Minis(string apiKey)    
        {
            return Builder.AddDirective("minis")
                .RequestAsync<List<int>>(apiKey);
        }

        public static Task<List<int>> Skins(string apiKey)    
        {
            return Builder.AddDirective("skins")
                .RequestAsync<List<int>>(apiKey);
        }

        public static Task<List<int>> Titles(string apiKey)   
        {
            return Builder.AddDirective("titles")
                .RequestAsync<List<int>>(apiKey);
        }

        public static Task<List<WalletEntry>> Wallet(string apiKey)   
        {
            return Builder.AddDirective("wallet")
                .RequestAsync<List<WalletEntry>>(apiKey);
        }
        
        public static Task<List<int>> Recipes(string apiKey)  
        {
            return Builder.AddDirective("recipes")
                .RequestAsync<List<int>>(apiKey);
        }

        public static Task<List<int>> Outfits(string apiKey)   
        {
            return Builder.AddDirective("outfits")
                .RequestAsync<List<int>>(apiKey);
        }

        public static Task<List<AccountMastery>> Masteries(string apiKey)   
        {
            return Builder.AddDirective("masteries")
                .RequestAsync<List<AccountMastery>>(apiKey);
        }

        public static Task<List<string>> Raids(string apiKey) {
            return Builder.AddDirective("raids")
                .RequestAsync<List<string>>(apiKey);
        }

        public static Task<List<string>> Dungeons(string apiKey) {
            return Builder.AddDirective("dungeons")
                .RequestAsync<List<string>>(apiKey);
        }

        public static Task<List<Cat>> HomeCats(string apiKey) {
            return Builder.AddDirective("home")
                .AddDirective("cats")
                .RequestAsync<List<Cat>>(apiKey);
        }

        public static Task<List<string>> HomeNodes(string apiKey) {
            return Builder.AddDirective("home")
                .AddDirective("nodes")
                .RequestAsync<List<string>>(apiKey);
        }
        
        public static Task<List<int>> Gliders(string apiKey) {
            return Builder.AddDirective("gliders")
                .RequestAsync<List<int>>(apiKey);
        }
    }
}
