using GuildWars2API.Model.Color;
using GuildWars2Guild.Classes.Resources;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    class ToEmblemColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            int colorId;
            if(int.TryParse(value.ToString(), out colorId) && colorId != 0) {
                Color color = ResourceManager.Instance.GetResource<Color>(colorId);
                if(color != null) 
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, (byte)color.BaseRGB[0], (byte)color.BaseRGB[1], (byte)color.BaseRGB[2]));
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
