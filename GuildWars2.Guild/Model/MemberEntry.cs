using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Resources;
using Utility.Providers;

namespace GuildWars2Guild.Model
{
    class OrderEntry : Member
    {
        private int _order = 0;
        public int Order
        {
            get {
                if(_order == 0) {
                    var rank = ResourceProvider.Instance.GetResource<Rank>(RankName);
                    if(rank != null)
                        _order = rank.Order;
                }
                return _order;
            }
        }
    }
}
