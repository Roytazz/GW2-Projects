using GuildWars2API.Model.Guild;
using GuildWars2API.Model.Value;

namespace GuildWars2Guild.Model
{
    class GoldEntry : LogEntry
    {
        public ItemPrice Value => new ItemPrice(Coins);

        public string DateString => Time.ToString("H:mm - d MMM \\'yy");
    }
}
