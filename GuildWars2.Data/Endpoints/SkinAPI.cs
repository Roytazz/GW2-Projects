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
    public static class SkinAPI
    {
        public static List<Skin> GetAccountSkins(string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user != null)
                    return db.Skin.Where(x => x.UserID == user.ID).ToList();
            }
            return new List<Skin>();
        }

        public static async Task AddSkins(List<API.Model.Items.Skin> skins, string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user == null)
                    return;
                foreach (var skin in skins) {
                    db.Skin.Add(new Skin { SkinID = skin.ID, UserID = user.ID });
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
