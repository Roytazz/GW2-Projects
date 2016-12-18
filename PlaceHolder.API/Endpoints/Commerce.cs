using GuildWars2APIPlaceHolder.Model.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder
{
    public static class CommerceAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("commerce"); } }

        #region Transactions    
        public static List<Transaction> SellsCurrent(string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("current")
                .AddPointer("sells")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> SellsCurrent(int pageCount, int page, string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("current")
                .AddPointer("sells")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> SellsHistory(string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("history")
                .AddPointer("sells")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> SellsHistory(int pageCount, int page, string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("history")
                .AddPointer("sells")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysCurrent(string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("current")
                .AddPointer("buys")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysCurrent(int pageCount, int page, string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("current")
                .AddPointer("buys")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysHistory(string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("history")
                .AddPointer("buys")
                .Request<List<Transaction>>(apiKey);
        }

        public static List<Transaction> BuysHistory(int pageCount, int page, string apiKey)
        {
            return Builder.AddPointer("transactions")
                .AddPointer("history")
                .AddPointer("buys")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Transaction>>(apiKey);
        }
        #endregion Transactions

        #region Listings
        public static ItemListing Listings(int itemID)
        {
            return Builder.AddPointer("listings")
                .AddPointer(itemID.ToString())
                .Request<ItemListing>();
        }

        public static List<ItemListing> Listings(List<int> itemIDs)
        {
            return Builder.AddPointer("listings")
                .AddParam("ids", itemIDs)
                .Request<List<ItemListing>>();
        }

        public static ItemListingAggregated ListingsAggregated(int itemID)
        {
            return Builder.AddPointer("prices")
                .AddPointer(itemID.ToString())
                .Request<ItemListingAggregated>();
        }

        public static List<ItemListingAggregated> ListingsAggregated(List<int> itemIDs)
        {
            return Builder.AddPointer("prices")
                .AddParam("ids", itemIDs)
                .Request<List<ItemListingAggregated>>();
        }
        #endregion Listings

        #region Exchange
        public static Exchange ExchangeToGold(int gems)
        {
            return Builder.AddPointer("exchange")
                .AddPointer("gems")
                .AddParam("quantity", gems.ToString())
                .Request<Exchange>();
        }

        public static Exchange ExchangeToGems(int coins)
        {
            return Builder.AddPointer("exchange")
                .AddPointer("coins")
                .AddParam("quantity", coins.ToString())
                .Request<Exchange>();
        }
        #endregion Exchange
    }
}
