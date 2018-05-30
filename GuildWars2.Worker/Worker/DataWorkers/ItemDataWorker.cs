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

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public async Task Run(CancellationToken token) {
            var page = 0;
            while (true) {
                token.ThrowIfCancellationRequested();

                SetProgress("Requesting Page #" + page + "...", 0);
                var pageResult = await ItemAPI.Items(MAX_ITEM_PER_PAGE, page);
                SetProgress("Retrieving saved items", 10);
                var itemIDs = pageResult.Select(x => x.ID).ToList();
                var dbItems = await DataAPI.GetItems(itemIDs);
                SetProgress("Comparing saved and retrieved items", 35);
                var newItems = GetNewItems(pageResult, dbItems);

                SetProgress("Saving" + newItems.Count + " new/changed items", 50);
                await DataAPI.AddItems(newItems);

                SetProgress("Requesting ItemListings", 80);
                var listings = await CommerceAPI.ListingsAggregated(pageResult.Select(x => x.ID).ToList());

                SetProgress("Updating ItemListings", 90);
                await DataAPI.AddItemSellable(pageResult, listings);

                page++;
                if (pageResult.Count < 200)
                    break;
            }
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

        private void SetProgress(string msg, int partialProgress) {
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs { Message = msg, PartialProgress = partialProgress });
        }
    }
}
