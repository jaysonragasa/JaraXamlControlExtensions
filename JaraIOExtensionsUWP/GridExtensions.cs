using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Jara.Xaml.Control.Extension
{
    public class GridEx
    {
        static char _defaultRowColSeparator = '/';

        #region RowDefinitions
        public static readonly DependencyProperty RowDefinitionsProperty = DependencyProperty.RegisterAttached(
            "RowDefinitions",
            typeof(string),
            typeof(Grid),
            new PropertyMetadata("*", OnRowDefinitionsPropertyChanged));

        public static string GetRowDefinitions(DependencyObject element)
        {
            return (string)element.GetValue(RowDefinitionsProperty);
        }

        public static void SetRowDefinitions(DependencyObject element, string value)
        {
            element.SetValue(RowDefinitionsProperty, value);
        }

        private static void OnRowDefinitionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            //var element = d as Grid;

            //if (element != null)
            //{
            //    element.RowDefinitions.Clear();

            //    // get values
            //    string[] values = args.NewValue.ToString().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        string v = values[i].Trim();
            //        double parsedNumber = 0;

            //        // auto
            //        if (v.ToLowerInvariant() == "auto" || v == "~")
            //        {
            //            element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            //        }
            //        else if (v == "*")
            //        {
            //            element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //        }
            //        else if (v.Last() == '*')
            //        {
            //            var val = v.Substring(0, v.IndexOf('*'));

            //            if (double.TryParse(val, out parsedNumber))
            //            {
            //                element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber, GridUnitType.Star) });
            //            }
            //        }
            //        else if (double.TryParse(v, out parsedNumber))
            //        {
            //            element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber) });
            //        }
            //    }
            //}

            RebuildDefinitions(d, args.NewValue.ToString() + _defaultRowColSeparator);
        }
        #endregion

        #region ColumnDefinitions
        public static readonly DependencyProperty ColumnDefinitionsProperty = DependencyProperty.RegisterAttached(
            "ColumnDefinitions",
            typeof(string),
            typeof(Grid),
            new PropertyMetadata("*", OnColumnDefinitionsPropertyChanged));

        public static string GetColumnDefinitions(DependencyObject element)
        {
            return (string)element.GetValue(ColumnDefinitionsProperty);
        }

        public static void SetColumnDefinitions(DependencyObject element, string value)
        {
            element.SetValue(ColumnDefinitionsProperty, value);
        }

        private static void OnColumnDefinitionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            //var element = d as Grid;

            //if (element != null)
            //{
            //    // get values
            //    string[] values = args.NewValue.ToString().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        string v = values[i].Trim();
            //        double parsedNumber = 0.0d;

            //        // auto
            //        if (v.ToLowerInvariant() == "auto" || v == "~")
            //        {
            //            element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            //        }
            //        else if (v == "*")
            //        {
            //            element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //        }
            //        else if (v.Last() == '*')
            //        {
            //            var val = v.Substring(0, v.IndexOf('*'));

            //            if (double.TryParse(val, out parsedNumber))
            //            {
            //                element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber, GridUnitType.Star) });
            //            }
            //        }
            //        else if (double.TryParse(v, out parsedNumber))
            //        {
            //            element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber) });
            //        }
            //    }
            //}

            RebuildDefinitions(d, _defaultRowColSeparator + args.NewValue.ToString());
        }
        #endregion

        #region GridDefinitions
        public static readonly DependencyProperty GridDefinitionsProperty = DependencyProperty.RegisterAttached(
            "GridDefinitions",
            typeof(string),
            typeof(Grid),
            new PropertyMetadata("*" + _defaultRowColSeparator + "*", OnGridDefinitionsPropertyChanged));

        public static string GetGridDefinitions(DependencyObject element)
        {
            return (string)element.GetValue(GridDefinitionsProperty);
        }

        public static void SetGridDefinitions(DependencyObject element, string value)
        {
            element.SetValue(GridDefinitionsProperty, value);
        }

        private static void OnGridDefinitionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            RebuildDefinitions(d, args.NewValue.ToString());
        }
        #endregion

        #region RowColumn
        public static readonly DependencyProperty RowColumnProperty = DependencyProperty.RegisterAttached(
            "RowColumn",
            typeof(string),
            typeof(FrameworkElement),
            new PropertyMetadata(null, OnRowColumnPropertyChanged));

        public static string GetRowColumn(DependencyObject element)
        {
            return (string)element.GetValue(RowColumnProperty);
        }

        public static void SetRowColumn(DependencyObject element, string value)
        {
            element.SetValue(RowColumnProperty, value);
        }

        private static void OnRowColumnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var element = d as FrameworkElement;

            if (element != null)
            {
                string rowcolvalue = args.NewValue.ToString().ToLowerInvariant();

                {
                    string[] rowcols = rowcolvalue.Split(_defaultRowColSeparator);
                    for (int i = 0; i < rowcols.Length; i++)
                    {
                        string[] vals = rowcols[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (i == 0)
                        {
                            if (vals.Length == 1) Grid.SetRow(element, int.Parse(vals[0]));
                            else if (vals.Length == 2)
                            {
                                Grid.SetRow(element, int.Parse(vals[0]));
                                Grid.SetRowSpan(element, int.Parse(vals[1]));
                            }
                        }
                        else if (i == 1)
                        {
                            if (vals.Length == 1) Grid.SetColumn(element, int.Parse(vals[0]));
                            else if (vals.Length == 2)
                            {
                                Grid.SetColumn(element, int.Parse(vals[0]));
                                Grid.SetColumnSpan(element, int.Parse(vals[1]));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region methods
        static void RebuildDefinitions(DependencyObject d, string newvalue)
        {
            var element = d as Grid;

            if (element != null)
            {
                element.ColumnDefinitions.Clear();
                element.RowDefinitions.Clear();

                string rowcolvalue = newvalue.ToLowerInvariant();

                //int semicolpos = rowcolvalue.IndexOf(_defaultRowColSeparator);
                //if (semicolpos != -1 // must have semi-colon
                //    //&& semicolpos != 0 // cannot be the very first character
                //    //&& semicolpos != rowcolvalue.Length - 1 // and cannot be the very last character
                //    )
                {
                    string[] rowcols = rowcolvalue.Split(_defaultRowColSeparator);
                    //string[] rows = rowcols[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //string[] cols = rowcols.Length > 1 ? rowcols[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[] { };

                    for (int i = 0; i < rowcols.Length; i++)
                    {
                        string[] vals = rowcols[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int j = 0; j < vals.Length; j++)
                        {
                            string v = vals[j].Trim();
                            double parsedNumber = 0.0d;

                            // auto
                            if (v.ToLowerInvariant() == "auto" || v == "~")
                            {
                                if (i == 0) element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                                else if (i == 1) element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                            }
                            else if (v == "*")
                            {
                                if (i == 0) element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                                else if (i == 1) element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                            }
                            else if (v.Last() == '*')
                            {
                                var val = v.Substring(0, v.IndexOf('*'));
                                if (double.TryParse(val, out parsedNumber))
                                {
                                    if (i == 0) element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber, GridUnitType.Star) });
                                    else if (i == 1) element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber, GridUnitType.Star) });
                                }
                            }
                            else if (double.TryParse(v, out parsedNumber))
                            {
                                if (i == 0) element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber, GridUnitType.Pixel) });
                                else if (i == 1) element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber, GridUnitType.Pixel) });
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}