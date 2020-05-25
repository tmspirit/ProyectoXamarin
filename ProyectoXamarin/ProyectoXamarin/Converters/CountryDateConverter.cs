using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace ProyectoXamarin.Converters
{
    public class CountryDateConverter : IValueConverter
    {
        public string DateFormat { get; set; }
        public string CultereCountry { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime objdate = (DateTime)value;
            string formatDate = objdate.ToString(DateFormat, new CultureInfo(CultereCountry));
            return formatDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
