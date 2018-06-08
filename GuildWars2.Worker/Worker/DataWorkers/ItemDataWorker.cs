using GuildWars2.API;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker.DataWorker
{
    public class ItemDataWorker : IDataWorker
    {
        private static readonly int MAX_ITEM_PER_PAGE = 200;
        private static readonly string FILE_LOCATION = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "new-entries.json");

        private bool _waitForUser;
        private bool _saveNewItems;
        private bool _onlyUpdateNewItemListings;

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public ItemDataWorker(bool waitForUser = false, bool saveNewItems = false, bool onlyUpdateNewItemListings = false) {
            _waitForUser = waitForUser;
            _saveNewItems = saveNewItems;
            _onlyUpdateNewItemListings = onlyUpdateNewItemListings;
        }

        public async Task Run(CancellationToken token) {
            var page = 0;
            while (true) {
                token.ThrowIfCancellationRequested();

                SetProgress("Requesting Page #" + page, 0);
                var pageResult = await ItemAPI.Items(MAX_ITEM_PER_PAGE, page);
                SetProgress("#" + page + ": Retrieving saved items", 10);
                var itemIDs = pageResult.Select(x => x.ID).ToList();
                var dbItems = await DataAPI.GetItems(itemIDs);
                SetProgress("#" + page + ": Comparing saved and retrieved items", 35);
                var newItems = GetNewItems(pageResult, dbItems);

                if (newItems.Count > 0) {
                    SetProgress("#" + page + ": Saving " + newItems.Count + " new/changed items", 50);
                    await DataAPI.AddItems(newItems);
                }

                SetProgress("#" + page + ": Requesting ItemListings", 80);
                var listingItemIDs = new List<int>();
                if(_onlyUpdateNewItemListings)
                    listingItemIDs = newItems.Select(x => x.ID).ToList();
                else
                    listingItemIDs = pageResult.Select(x => x.ID).ToList();

                var listings = new List<ItemListingAggregated>();
                if (listingItemIDs.Count > 0)
                    listings = await CommerceAPI.ListingsAggregated(listingItemIDs);
                
                SetProgress("#" + page + ": Updating ItemListings", 90);
                if (listings.Count > 0) {
                    if (_onlyUpdateNewItemListings)
                        await DataAPI.AddItemSellable(newItems, listings);
                    else
                        await DataAPI.AddItemSellable(pageResult, listings);
                }

                page++;
                if (pageResult.Count < 200)
                    break;
            }
        }

        private List<Item> GetNewItems(List<Item> apiItems, List<Item> dbItems) {
            var newItems = new List<Item>();
            var changedItems = new List<Item>();

            foreach (var apiItem in apiItems) {
                if (dbItems.Any(x => x.ID == apiItem.ID)) {
                    var isChanged = new DiffConsoleHelper<Item>(apiItem, dbItems.FirstOrDefault(x => x.ID == apiItem.ID)).DiffObject(_waitForUser);
                    if (isChanged)
                        changedItems.Add(apiItem);
                }
                else
                    newItems.Add(apiItem);
            }

            if (_saveNewItems)
                WriteNewItems(newItems);

            return newItems.Concat(changedItems).ToList();
        }

        private void SetProgress(string msg, int partialProgress) {
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs { Message = msg, PartialProgress = partialProgress });
        }

        private void WriteNewItems(List<Item> newItems) {
            var jsonData = string.Empty;
            if (File.Exists(FILE_LOCATION)) {
                 jsonData = File.ReadAllText(FILE_LOCATION);
            }

            var items = JsonConvert.DeserializeObject<List<Item>>(jsonData) ?? new List<Item>();
            items.AddRange(newItems);

            using (FileStream fs = new FileStream(FILE_LOCATION, FileMode.Create)) {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8)) {
                    w.WriteLine(JsonConvert.SerializeObject(items));
                }
            }
        }
    }
}
