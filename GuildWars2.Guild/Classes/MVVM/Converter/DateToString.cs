using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Converter
{
    class DateToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if(!(value is DateTime))
                return Binding.DoNothing;

            if(parameter != null) {
                return ((DateTime)value).ToString(parameter.ToString());
            }
            else {
                return ((DateTime)value).ToString("H:mm - d MMM \\'yy");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
