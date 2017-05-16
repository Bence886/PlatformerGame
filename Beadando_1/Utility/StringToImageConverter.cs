using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Beadando_1
{
    public class StringToImageConverter :IValueConverter
    {
        /*
         *value: string -> a kép kiterjesztés nélküli neve -- a kiterjesztés kötelezően PNG!! --
         */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(string)) throw new InvalidOperationException("Stringet kell megadnod!");
            string seged = (string)value;
            return new BitmapImage(new Uri(String.Format("pack://application:,,,/Resources/{0}.png", seged))); //megadott nevű erőforrás betöltése képként
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing; //másik irányba ne csináljon semmit
        }
    }
}
