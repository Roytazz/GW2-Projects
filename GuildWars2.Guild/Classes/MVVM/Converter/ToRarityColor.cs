using GuildWars2API.Model.Items;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    class ToRarityColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value is string && !string.IsNullOrEmpty(value as string)) {
                var type = value as string;
                if(type.Equals("Junk")) {
                    return "#FFA6A6A6";
                }
                else if(type.Equals("Basic")) {
                    return "#FFFFFF";
                }
                else if(type.Equals("Fine")) {
                    return "#4099ff";
                }
                else if(type.Equals("Masterwork")) {
                    return "#669900";
                }
                else if(type.Equals("Rare")) {
                    return "#FFFF00";
                }
                else if(type.Equals("Exotic")) {
                    return "#FF9933";
                }
                else if(type.Equals("Ascended")) {
                    return "#FF3399";
                }
                else if(type.Equals("Legendary")) {
                    return "#CC00CC";
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
