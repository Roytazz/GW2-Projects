using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Discord.Services
{
    public class ApiService
    {
        public string Dailies()
        {
            //var result = await API.AchievementsAPI.DailyAchievements();
            return "today";
        }

        public string TomorrowDailies()
        {
            //var result = await API.AchievementsAPI.DailyAchievementsTomorrow();
            return "tomorrow";
        }
    }
}
