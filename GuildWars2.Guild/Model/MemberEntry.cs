using GuildWars2.API.Model.Guild;
using GuildWars2.Guild.Classes.Resources;

namespace GuildWars2.Guild.Model
{
    class OrderEntry : Member
    {
        private int _order = 0;
        public int Order
        {
            get {
                if(_order == 0) {
                    var rank = ResourceProvider.Instance.GetResource<Rank>(RankName).GetAwaiter().GetResult();
                    if(rank != null)
                        _order = rank.Order;
                }
                return _order;
            }
        }
    }
}
