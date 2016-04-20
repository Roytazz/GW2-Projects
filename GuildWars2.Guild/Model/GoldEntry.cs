using GuildWars2API.Model.Guild;
using GuildWars2API.Model.Value;

namespace GuildWars2Guild.Model
{
    class GoldEntry
    {
        public ItemPrice Value => new ItemPrice(LogEntry.Coins);

        public string DateString => LogEntry.Time.ToShortTimeString() + " " + LogEntry.Time.ToLongDateString();

        public LogEntry LogEntry { get; set; }
    }
}
