using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Boilerplate.Converters
{
    public class ValidatableObjectErrorMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is List<string> errorList)
                return errorList.FirstOrDefault();

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
