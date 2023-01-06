using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.Services
{
    public class Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values.Length == 2)
            {
                string name = values[0].ToString();
                string age = values[1].ToString();
                return new MultiBindClass { Value1 = name, Value2 = age };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MultiBindClass
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
