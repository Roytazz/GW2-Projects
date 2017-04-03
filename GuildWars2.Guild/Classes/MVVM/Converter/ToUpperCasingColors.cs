using System;
using System.Globalization;
using System.Windows.Data;

namespace GuildWars2.Guild.Classes.MVVM.Converter
{
    public class ToUpperCasingColors : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(!string.IsNullOrEmpty(value.ToString())) {
                string text = value.ToString();
                if(text.Contains("light"))
                    text = text.Insert(5, " ");

                if(text.Contains("deep"))
                    text = text.Insert(4, " ");
                return text.ToString().ToUpper();
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}