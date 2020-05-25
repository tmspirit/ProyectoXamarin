using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace ProyectoXamarin.Converters
{
    public class SpanishDateConverter : IValueConverter
    {
        public string SpanishFormat { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime objdate = (DateTime)value;
            string formatDate = objdate.ToString(SpanishFormat, new CultureInfo("es-ES"));
            return formatDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
