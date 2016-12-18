using GuildWars2API.Model.OldValue;
using System;

namespace GuildWars2API.Event.PriceEvent
{
    public class PriceTriggerEventArgs : EventArgs
    {
        public int ItemID { get; set; }

        public int ItemCount { get; set; }

        public ItemPrice Threshold { get; set; }

        public ItemPrice CurrentPrice { get; set; }

    }
}