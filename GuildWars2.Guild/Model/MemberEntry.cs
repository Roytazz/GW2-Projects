using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Resources;

namespace GuildWars2Guild.Model
{
    class OrderEntry : Member
    {
        public int Order
        {
            get {
                var rank = ResourceManager.Instance.GetResource<Rank>(RankName);
                if(rank != null)
                    return rank.Order;

                return 0;
            }
        }
    }
}
