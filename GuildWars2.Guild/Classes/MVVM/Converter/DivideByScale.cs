using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    public class DivideByScale : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(double.Parse(value.ToString()) == 0)
                return 1;
            
            if(parameter != null) 
                return double.Parse(value.ToString()) / int.Parse(parameter.ToString());
            
            return double.Parse(value.ToString()) / 940;

            //return double.Parse(value.ToString()) / 720; //This is the optimal scale
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
