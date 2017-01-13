using System;

namespace GuildWars2API.Model.Commerce
{
    public class ItemPrice : IComparable<ItemPrice>
    {
        public int Coins { get; private set; }

        public int Gold => Coins / 10000;

        public int Silver {
            get {
                int rest = Coins - (Gold * 10000);
                return rest / 100;
            }
        }

        public int Copper { 
            get {
                int rest = Coins - (Gold * 10000);
                return rest - (Silver * 100);
            }
        }

        public ItemPrice(int totalCoins = 0) {
            Coins = totalCoins;
        }

        public int CompareTo(ItemPrice other) {
            if(other == null)
                return 1;

            if(Coins > other.Coins) {
                return 1;
            }
            else if(Coins < other.Coins) {
                return -1;
            }

            return 0;
        }

        public static bool operator <(ItemPrice e1, ItemPrice e2) => e1.CompareTo(e2) < 0;

        public static bool operator >(ItemPrice e1, ItemPrice e2) => e1.CompareTo(e2) > 0;
    }
}