using GuildWars2.API.Model.Items;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GuildWars2.Data.DataAPI;

namespace GuildWars2.Data
{
    public static class DyeAPI
    {
        public static List<Dye> GetAccountDyes(string apiKey) {
            using(var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if(user != null)
                    return db.Dye.Where(x => x.UserID == user.ID).ToList();
            }
            return new List<Dye>();
        }

        public static async void AddDyes(List<API.Model.Items.Item> dyes, string apiKey) {
            using(var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user == null)
                    return;
                foreach (var dye in dyes) {
                    db.Dye.Add(new Dye { DyeID = dye.ID, UserID = user.ID });
                }
                await db.SaveChangesAsync();
            }
        }
    }
}