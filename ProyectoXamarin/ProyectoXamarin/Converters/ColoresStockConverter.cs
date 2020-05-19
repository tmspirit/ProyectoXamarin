using System;
using System.Globalization;
using Xamarin.Forms;

namespace ProyectoXamarin.Converters
{
    public class ColoresStockConverter : IValueConverter
    {
        public Color ColorNegativo { get; set; }
        public Color ColorPositivo { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor = (int)value;
            if (valor < 0) return this.ColorPositivo;
            else return this.ColorNegativo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
