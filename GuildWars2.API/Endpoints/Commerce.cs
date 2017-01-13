using GuildWars2API.Model.Commerce;
using System.Collections.Generic;

namespace GuildWars2API
{
    public static class CommerceAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("commerce"); } }

        #region Transactions    
        public static List<Transaction> SellsCurrent(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("sells")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> SellsCurrent(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("sells")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> SellsHistory(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("sells")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> SellsHistory(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("sells")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysCurrent(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("buys")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysCurrent(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("current")
                .AddDirective("buys")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysHistory(string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("buys")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysHistory(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("transactions")
                .AddDirective("history")
                .AddDirective("buys")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }
        #endregion Transactions

        #region Listings
        public static ItemListing Listings(int itemID)
        {
            return Builder.AddDirective("listings")
                .AddDirective(itemID.ToString())
                .Request<ItemListing>();
        }

        public static List<ItemListing> Listings(List<int> itemIDs)
        {
            return Builder.AddDirective("listings")
                .AddParam("ids", itemIDs)
                .Request<List<ItemListing>>();
        }

        public static ItemListingAggregated ListingsAggregated(int itemID)
        {
            return Builder.AddDirective("prices")
                .AddDirective(itemID.ToString())
                .Request<ItemListingAggregated>();
        }

        public static List<ItemListingAggregated> ListingsAggregated(List<int> itemIDs)
        {
            return Builder.AddDirective("prices")
                .AddParam("ids", itemIDs)
                .Request<List<ItemListingAggregated>>();
        }
        #endregion Listings

        #region Exchange
        public static Exchange ExchangeToGold(int gems)
        {
            return Builder.AddDirective("exchange")
                .AddDirective("gems")
                .AddParam("quantity", gems.ToString())
                .Request<Exchange>();
        }

        public static Exchange ExchangeToGems(int coins)
        {
            return Builder.AddDirective("exchange")
                .AddDirective("coins")
                .AddParam("quantity", coins.ToString())
                .Request<Exchange>();
        }
        #endregion Exchange
    }
}
