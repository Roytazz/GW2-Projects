using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Items;
using GuildWars2API.Model.Value;
using GuildWars2Guild.Classes.Resources;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    class ToItemPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value.GetType() == typeof(Item)) {
                var listing = ResourceManager.Instance.GetResource<ItemListing>((value as Item).ID);
                if(parameter is string && !string.IsNullOrEmpty(parameter as string) && listing != null) {
                    var type = (parameter as string).ToLower();
                    if(type.Equals("buys"))
                        return new ItemPrice(listing.Buys.UnitPrice);

                    if(type.Equals("sells"))
                        return new ItemPrice(listing.Sells.UnitPrice);
                }
            }
            return new ItemPrice();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
