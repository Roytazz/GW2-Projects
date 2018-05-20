using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static GuildWars2.Data.DataAPI;

namespace GuildWars2.Data
{
    public static class MiniAPI
    {
        public static List<Mini> GetAccountMinis(string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user != null)
                    return db.Mini.Where(x => x.UserID == user.ID).ToList();
            }
            return new List<Mini>();
        }

        public static async void AddMinis(List<API.Model.Items.Item> minis, string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user == null)
                    return;
                foreach (var mini in minis) {
                    db.Mini.Add(new Mini { MiniID = mini.ID, UserID = user.ID });
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
