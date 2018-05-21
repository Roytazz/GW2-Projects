using GuildWars2.API.Model.Items;
using GuildWars2.Data.Database;
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
                    if (!db.Item.Any(x => x.ID == item.ID)) //Implement UPDATE and Equals()
                        db.Item.Add(item);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
