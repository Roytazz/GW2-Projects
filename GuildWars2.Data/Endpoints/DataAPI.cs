using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Data.Endpoints
{
    public static class DataAPI
    {
        #region Items
        public static async Task AddItems(List<Item> items) {
            using(var db = new DataContextFactory().CreateDbContext()) {
                foreach (var item in items) {
                    if (db.Item.Any(x => x.ID == item.ID)) {
                        var existingItem = await db.Item.FirstOrDefaultAsync(x => x.ID == item.ID);
                        db.Item.Remove(existingItem);
                    }
                    db.Item.Add(item);
                }
                await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Item>> GetItems(List<int> itemIDs) {
            using (var db = new DataContextFactory().CreateDbContext()) {
                return await db.Item.Where(x => itemIDs.Contains(x.ID)).ToListAsync();
            }
        }

        public static async Task<List<Item>> GetItems(Func<Item, bool> predicate) {
            using (var db = new DataContextFactory().CreateDbContext()) {
                return await db.Item.Where(x => predicate(x)).ToListAsync();
            }
        }

        public static async Task RemoveItems(List<Item> items) {
            using (var db = new DataContextFactory().CreateDbContext()) {
                var dbItems = await db.Item.Where(x => items.Select(y => y.ID).Contains(x.ID)).ToListAsync();
                db.Item.RemoveRange(dbItems);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<Dictionary<int, List<int>>> GetSkinItemGroups(List<int> skinIDs) {
            var result = new Dictionary<int, List<int>>();
            using (var db = new DataContextFactory().CreateDbContext()) {
                foreach (var skinID in skinIDs) {
                    var items = await db.Item.Where(x => x.DefaultSkin == skinID).Select(x=>x.ID).ToListAsync();
                    result.Add(skinID, items);
                }
            }
            return result;
        }
        #endregion Items

        #region ItemSellable
        public static async Task AddItemSellable(List<Item> items, List<ItemListingAggregated> listings) {   
            using (var db = new DataContextFactory().CreateDbContext()) {
                var existingItems = db.ItemSellable.Where(x => items.Select(y => y.ID).ToList().Contains(x.ItemID));
                foreach (var item in items) {
                    var isSellable = listings.Any(x => x.ItemID == item.ID);
                    if (isSellable && existingItems.Any(x => x.ItemID == item.ID)) {
                        var existingItem = await db.ItemSellable.FirstOrDefaultAsync(x => x.ItemID == item.ID);
                        db.Attach(existingItem);
                        existingItem.Sellable = isSellable;
                    }
                    else {
                        db.ItemSellable.Add(new ItemSellable {
                            ItemID = item.ID,
                            Sellable = isSellable
                        });
                    }
                }
                await db.SaveChangesAsync();
            }
        }

        public static async Task<List<int>> GetItemSellable(List<int> itemIDs) {
            using (var db = new DataContextFactory().CreateDbContext()) {
                return await db.ItemSellable.Where(x => itemIDs.Contains(x.ItemID) && x.Sellable && !x.Blacklisted)
                    .Select(x => x.ItemID).ToListAsync();
            }
        }
        #endregion ItemSellable
    }
}
