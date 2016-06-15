using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    public class DivideByScale : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            double scale;
            if(double.TryParse(value.ToString(), out scale) && scale == 0) {

                double scaleParam;
                if(parameter != null && double.TryParse(parameter.ToString(), out scaleParam))
                    return scale / scaleParam;

                return scale / 940;
                //return scale / 720; //This is the optimal scale
            }
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
