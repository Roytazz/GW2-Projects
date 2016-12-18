using GuildWars2API.Model.Guild;
using GuildWars2API.Model.OldValue;

namespace GuildWars2Guild.Model
{
    public class GoldEntry : LogEntry
    {
        public ItemPrice Value => new ItemPrice(Coins);
    }
}
