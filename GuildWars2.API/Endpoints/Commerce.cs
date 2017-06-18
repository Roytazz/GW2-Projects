using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class CommerceAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("commerce"); } }

        #region Transactions    
        public static Task<List<Transaction>> SellsCurrent(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("sells")
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> SellsCurrent(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("sells")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> SellsHistory(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("sells")
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> SellsHistory(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("sells")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> BuysCurrent(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("buys")
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> BuysCurrent(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("buys")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> BuysHistory(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("buys")
                .RequestAsync<List<Transaction>>(apiKey);
        }

        public static Task<List<Transaction>> BuysHistory(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("buys")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Transaction>>(apiKey);
        }
        #endregion Transactions

        #region Listings
        public static Task<ItemListing> Listings(int itemID)
        {
            return Builder.AddDirective("listings")
                .AddDirective(itemID.ToString())
                .RequestAsync<ItemListing>();
        }

        public static Task<List<ItemListing>> Listings(List<int> IDs)
        {
            return Builder.AddDirective("listings")
                .AddParam("ids", IDs)
                .RequestAsync<List<ItemListing>>();
        }

        public static Task<ItemListingAggregated> ListingsAggregated(int IDs)
        {
            return Builder.AddDirective("prices")
                .AddDirective(IDs.ToString())
                .RequestAsync<ItemListingAggregated>();
        }

        public static Task<List<ItemListingAggregated>> ListingsAggregated(List<int> IDs)
        {
            return Builder.AddDirective("prices")
                .AddParam("ids", IDs)
                .RequestAsync<List<ItemListingAggregated>>();
        }
        #endregion Listings

        #region Exchange
        public static Task<Exchange> ExchangeToGold(int gems)
        {
            return Builder.AddDirective("exchange")
                .AddDirective("gems")
                .AddParam("quantity", gems.ToString())
                .RequestAsync<Exchange>();
        }

        public static Task<Exchange> ExchangeToGems(int coins)
        {
            return Builder.AddDirective("exchange")
                .AddDirective("coins")
                .AddParam("quantity", coins.ToString())
                .RequestAsync<Exchange>();
        }
        #endregion Exchange

        public static Task<DeliveryBox> DeliveryBox(string apiKey) {
            return Builder.AddDirective("delivery")
                .RequestAsync<DeliveryBox>();
        }
    }
}
