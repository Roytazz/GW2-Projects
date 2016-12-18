using System;

namespace GuildWars2APIPlaceHolder.Model.Commerce
{
    public class ItemPrice : IComparable<ItemPrice>
    {
        private int _totalCoins;

        public int Gold => _totalCoins / 10000;

        public int Silver {
            get {
                int rest = _totalCoins - (Gold * 10000);
                return rest / 100;
            }
        }

        public int Copper { 
            get {
                int rest = _totalCoins - (Gold * 10000);
                return rest - (Silver * 100);
            }
        }

        public ItemPrice(int totalCoins) {
            _totalCoins = totalCoins;
        }

        public int CompareTo(ItemPrice other) {
            if(other == null)
                return 1;

            if(_totalCoins > other._totalCoins) {
                return 1;
            }
            else if(_totalCoins < other._totalCoins) {
                return -1;
            }

            return 0;
        }

        public static bool operator <(ItemPrice e1, ItemPrice e2) => e1.CompareTo(e2) < 0;

        public static bool operator >(ItemPrice e1, ItemPrice e2) => e1.CompareTo(e2) > 0;
    }
}