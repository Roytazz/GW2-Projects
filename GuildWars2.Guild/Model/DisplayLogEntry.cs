using GuildWars2API.Model.Guild;

namespace GuildWars2Guild.Model
{
    public class DisplayLogEntry : LogEntry
    {
        public string DateString => Time.ToString("H:mm - d MMM \\'yy");

        public string ShortDateString => Time.ToString("d MMM \\'yy");
    }
}
