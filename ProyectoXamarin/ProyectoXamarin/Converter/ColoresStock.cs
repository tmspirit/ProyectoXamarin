using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.Converter
{
    public class ColoresStock : IValueConverter
    {
        public Color ColorNegativo { get; set; }
        public Color ColorPositivo { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int numero = (int)value;
            if (numero < 0) return this.ColorPositivo;
            else return this.ColorNegativo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
