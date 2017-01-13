using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Guild;

namespace GuildWars2Guild.Model
{
    public class GoldEntry : LogEntry
    {
        public ItemPrice Value => new ItemPrice(Coins);
    }
}
