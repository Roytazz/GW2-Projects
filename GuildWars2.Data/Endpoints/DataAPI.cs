using GuildWars2.API.Model.Items;
using GuildWars2.Data.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Data.Endpoints
{
    public static class DataAPI
    {
        public static async Task AddItems(List<Item> items) {
            using(var db = new DataContextFactory().CreateDbContext()) {
                foreach (var item in items) {
                    if (db.Item.Any(x => x.ID == item.ID)) {
                        var foundItem = await db.Item.FirstOrDefaultAsync(x => x.ID == item.ID);
                        if (!foundItem.IsEqual(item)) {
                            var dbItem = await db.Item.FirstOrDefaultAsync(x => x.ID == item.ID);
                            db.Item.Remove(dbItem);
                            db.Item.Add(item);
                        }
                    }
                    else
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

        public static async Task RemoveItems(List<Item> items) {
            using (var db = new DataContextFactory().CreateDbContext()) {
                var dbItems = await db.Item.Where(x => items.Select(y => y.ID).Contains(x.ID)).ToListAsync();
                db.Item.RemoveRange(dbItems);
                await db.SaveChangesAsync();
            }
        }
    }

    public static class ItemExtension
    {
        public static bool IsEqual(this Item obj, Item item) {
            //TODO
            return true;
        }
    }
}
