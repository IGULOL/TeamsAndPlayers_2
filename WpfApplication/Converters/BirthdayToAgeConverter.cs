using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication.Converters
{
    [ValueConversion(typeof(string), typeof(int))]
    class BirthdayToAgeConverter : IValueConverter
    {
        //дата рождения => возраст
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime d1 = DateTime.Parse((string)value);
            DateTime d2 = DateTime.Now;
            return d2.Year - d1.Year - 1 +
            ((d2.Month > d1.Month || d2.Month == d1.Month && d2.Day >= d1.Day) ? 1 : 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
