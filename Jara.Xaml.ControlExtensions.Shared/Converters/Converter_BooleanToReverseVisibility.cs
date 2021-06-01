//using System;
//using System.Globalization;

//#if WINDOWS_UWP
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Data;
//#elif XAMARIN
//using Xamarin.Forms;
//#else
//using System.Windows;
//using System.Windows.Data;
//#endif

//namespace Jara.Xaml.Control.Converters
//{
//    public class BooleanToReverseVisibility : IValueConverter
//    {

//#if WINDOWS_UWP
//        public object Convert(object value, Type targetType, object parameter, string language)
//#else
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//#endif
//        {
//            Visibility visibility = Visibility.Visible;

//            if (value is bool)
//            {
//                visibility = (bool)value ? Visibility.Collapsed : Visibility.Visible;
//            }

//            return visibility;
//        }

//#if WINDOWS_UWP
//        public object ConvertBack(object value, Type targetType, object parameter, string language)
//#else
//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//#endif
//        {
//            return value;
//        }
//    }
//}