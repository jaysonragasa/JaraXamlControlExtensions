using HiSystems.Interpreter;
using Jara.Xaml.ControlExtensions.Shared.Interpreter;
using System;
using System.Globalization;

#if WINDOWS_UWP
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
#elif XAMARIN
using Xamarin.Forms;
#else
using System.Windows;
using System.Windows.Data;
#endif

namespace Jara.Xaml.Control.Converters
{
    public class Converter_EvalFx : IValueConverter
    {
#if WINDOWS_UWP
            public object Convert(object value, Type targetType, object parameter, string language)
#else
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#endif
        {
            object result = null;

            if (!string.IsNullOrEmpty((string)value))
            {
                string p = (string)parameter;
                p = p.Trim();

                var xp = EvalFx.Engine.Parse(p);
                xp.Variables["x"].Value = new Text((string)value);
                return xp.Execute<Text>().ToString();
            }

            return result;
        }

#if WINDOWS_UWP
            public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#endif
        {
            return value;
        }
    }
}