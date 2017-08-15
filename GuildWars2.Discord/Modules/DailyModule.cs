using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GuildWars2.Discord.Services;

namespace GuildWars2.Discord.Modules
{
    public class DailyModule : ModuleBase
    {
        private ApiService _api;

        public DailyModule(ApiService api) {
            _api = api;
        }

        [Command("daily")]
        public async Task ListDailies()
        {
            await ReplyAsync(_api.Dailies());  
        }

        [Command("daily+")]
        public async Task ListTomorrowDailies() {
            await ReplyAsync(_api.TomorrowDailies());
        }
        
        [Command("dailyTomorrow")]
        public async Task ListTomorrowDailiesOverload() {
            await ListTomorrowDailies();
        }
    }
}
