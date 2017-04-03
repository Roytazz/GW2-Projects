using GuildWars2.API.Model.Guild;
using GuildWars2.Guild.Classes.Resources;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2.Guild.Classes.MVVM.Converter
{
    class ToRankIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var rank = ResourceProvider.Instance.GetResource<Rank>(value.ToString()).GetAwaiter().GetResult();
            if(rank != null)
                return rank.Icon;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
