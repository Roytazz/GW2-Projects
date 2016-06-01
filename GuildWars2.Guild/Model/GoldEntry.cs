using GuildWars2API.Model.Value;

namespace GuildWars2Guild.Model
{
    public class GoldEntry : DisplayLogEntry
    {
        public ItemPrice Value => new ItemPrice(Coins);
    }
}
