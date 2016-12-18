using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Resources;

namespace GuildWars2Guild.Model
{
    class OrderEntry : Member
    {
        private int _order = 0;
        public int Order
        {
            get {
                if(_order == 0) {
                    var rank = ResourceManager.Instance.GetResource<Rank>(RankName);
                    if(rank != null)
                        _order = rank.Order;
                }
                return _order;
            }
        }
    }
}
