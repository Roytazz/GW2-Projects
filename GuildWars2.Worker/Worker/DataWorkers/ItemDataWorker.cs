using GuildWars2.API;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker.DataWorker
{
    public class ItemDataWorker : IDataWorker
    {
        private static readonly int MAX_ITEM_PER_PAGE = 200;

        public async Task Run(CancellationToken token) {
            var page = 228;
            Write(nameof(ItemDataWorker) + " starting...");
            while (true) {
                Write("Requesting Page #" + page + "...");
                var pageResult = await ItemAPI.Items(MAX_ITEM_PER_PAGE, page);
                var itemIDs = pageResult.Select(x => x.ID).ToList();
                var dbItems = await DataAPI.GetItems(itemIDs);
                var newItems = GetNewItems(pageResult, dbItems);

                Write("Retrieved " + newItems.Count + " new/changed items. Saving to DB...");

                await DataAPI.AddItems(newItems);
                Write("Saving completed! Requesting ItemListings...");

                var listings = await CommerceAPI.ListingsAggregated(pageResult.Select(x => x.ID).ToList());

                Write("Done Requesting ItemListings. Saving to DB...");

                await DataAPI.AddItemSellable(pageResult, listings);
                Write("Saving completed!");

                page++;
                if (pageResult.Count < 200)
                    break;
            }
            Write(string.Empty);
            Write(nameof(ItemDataWorker) + " done.");
        }

        private void Write(string msg) {
            Console.WriteLine(msg);
        }

        private List<Item> GetNewItems(List<Item> apiItems, List<Item> dbItems) {
            var result = new List<Item>();
            foreach (var apiItem in apiItems) {
                if (dbItems.Any(x => x.ID == apiItem.ID)) {
                    var isNew = JsonDiffConsoleHelper.DiffObject(apiItem, dbItems.FirstOrDefault(x => x.ID == apiItem.ID));
                    if (isNew)
                        result.Add(apiItem);
                }
                else
                    result.Add(apiItem);
            }
            return result;
        }
    }
}
