using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Guild;

namespace GuildWars2.Guild.Model
{
    public class GoldEntry : LogEntry
    {
        public ItemPrice Value => new ItemPrice(Coins);
    }
}
