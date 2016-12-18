using GuildWars2API.Model.OldValue;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    class ToItemPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            int totalCoins;
            if(int.TryParse(value.ToString(), out totalCoins)) 
                return new ItemPrice(totalCoins);

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
