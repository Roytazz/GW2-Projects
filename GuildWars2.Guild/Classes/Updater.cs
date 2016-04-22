namespace GuildWars2Guild.Classes
{
    public static class Updater
    {
        public static void Update() {
            var apikey = "EA50C40A-C88C-7D48-90EC-7D46C2C505C8F8E798A6-FD91-4580-A7A4-6A64B2826245";
            var results = GuildWars2API.GuildAPI.GetGuildLogByName("Frostgorge Champ Train", apikey);
            DBManager.AddLog(results);
        }
    }
}
