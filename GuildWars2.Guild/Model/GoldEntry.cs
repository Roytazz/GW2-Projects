using GuildWars2API.Model.Value;

namespace GuildWars2Guild.Model
{
    class GoldEntry : DisplayLogEntry
    {
        public ItemPrice Value => new ItemPrice(Coins);
    }
}
