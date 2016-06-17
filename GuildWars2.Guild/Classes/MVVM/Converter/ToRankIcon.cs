using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    class ToRankIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var rank = ResourceManager.Instance.GetResource<Rank>(value.ToString());
            if(rank != null)
                return rank.Icon;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
