using CMDL.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace CMDL.Converters
{
    public class FilterKeywordVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = Visibility.Collapsed;

            if (value != null)
            {
                var val = System.Convert.ToString(value);
                if (val == FilterConstants.CONTROL_NO ||
                    val == FilterConstants.FIRST_NAME ||
                    val == FilterConstants.LAST_NAME)
                    visibility = Visibility.Visible;
            }

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
