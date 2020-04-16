using Xamarin.Forms;
using System.Linq;
using System;

namespace Jara.Xaml.Control.Extension
{
    public class GridEx
    {
        static char _defaultRowColSeparator = '/';

        #region RowDefinitions
        public static readonly BindableProperty RowDefinitionsProperty = BindableProperty.CreateAttached("RowDefinitions", typeof(string), typeof(Grid), "*", defaultBindingMode: BindingMode.OneWay, validateValue: null, propertyChanged: OnRowDefinitionsPropertyChanged);

        public static string GetRowDefinitions(BindableObject element)
        {
            return (string)element.GetValue(RowDefinitionsProperty);
        }

        public static void SetRowDefinitions(BindableObject element, string value)
        {
            element.SetValue(RowDefinitionsProperty, value);
        }

        private static void OnRowDefinitionsPropertyChanged(BindableObject obj, object oldValue, object newValue)
        {
            //var element = obj as Grid;

            //if (element != null && newValue != null)
            //{
            //    RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();

            //    // get values
            //    string[] values = newValue.ToString().Split(',');

            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        string v = values[i].Trim();
            //        double parsedNumber = 0;

            //        // auto
            //        if (v.ToLowerInvariant() == "auto")
            //        {
            //            rowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            //        }
            //        else if (v == "*")
            //        {
            //            rowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //        }
            //        else if (v.Last() == '*')
            //        {
            //            var val = v.Substring(0, v.IndexOf('*'));

            //            if (double.TryParse(val, out parsedNumber))
            //            {
            //                rowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber, GridUnitType.Star) });
            //            }
            //        }
            //        else if (double.TryParse(v, out parsedNumber))
            //        {
            //            rowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber) });
            //        }
            //    }

            //    element.RowDefinitions = rowDefinitions;
            //}

            RebuildDefinitions(obj, newValue.ToString());
        }
        #endregion

        #region ColumnDefinitions
        public static readonly BindableProperty ColumnDefinitionsProperty = BindableProperty.CreateAttached("ColumnDefinitions", typeof(string), typeof(Grid), "*", defaultBindingMode: BindingMode.OneWay, validateValue: null, propertyChanged: OnColumnDefinitionsPropertyChanged);

        public static string GetColumnDefinitions(BindableObject element)
        {
            return (string)element.GetValue(ColumnDefinitionsProperty);
        }

        public static void SetColumnDefinitions(BindableObject element, string value)
        {
            element.SetValue(ColumnDefinitionsProperty, value);
        }

        private static void OnColumnDefinitionsPropertyChanged(BindableObject obj, object oldValue, object newValue)
        {
            //var element = obj as Grid;

            //if (element != null && newValue != null)
            //{
            //    ColumnDefinitionCollection colDefinitions = new ColumnDefinitionCollection();

            //    // get values
            //    string[] values = newValue.ToString().Split(',');

            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        string v = values[i].Trim();
            //        double parsedNumber = 0.0d;

            //        // auto
            //        if (v.ToLowerInvariant() == "auto")
            //        {
            //            colDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            //        }
            //        else if (v == "*")
            //        {
            //            colDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //        }
            //        else if (v.Last() == '*')
            //        {
            //            var val = v.Substring(0, v.IndexOf('*'));

            //            if (double.TryParse(val, out parsedNumber))
            //            {
            //                colDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber, GridUnitType.Star) });
            //            }
            //        }
            //        else if (double.TryParse(v, out parsedNumber))
            //        {
            //            colDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber, GridUnitType.Absolute) });
            //        }
            //    }

            //    element.ColumnDefinitions = colDefinitions;
            //}

            RebuildDefinitions(obj, _defaultRowColSeparator + newValue.ToString());
        }
        #endregion

        #region GridDefinitions
        public static readonly BindableProperty GridDefinitionsProperty = BindableProperty.CreateAttached("GridDefinitions", typeof(string), typeof(Xamarin.Forms.Grid), "*" + _defaultRowColSeparator.ToString() + "*", defaultBindingMode: BindingMode.OneWay, validateValue: null, propertyChanged: OnGridDefinitionsPropertyChanged);

        public static string GetGridDefinitions(BindableObject element)
        {
            return (string)element.GetValue(GridDefinitionsProperty);
        }

        public static void SetGridDefinitions(BindableObject element, string value)
        {
            element.SetValue(GridDefinitionsProperty, value);
        }

        private static void OnGridDefinitionsPropertyChanged(BindableObject obj, object oldValue, object newValue)
        {
            RebuildDefinitions(obj, newValue.ToString());
        }
        #endregion

        #region RowColumn
        public static readonly BindableProperty RowColumnProperty = BindableProperty.CreateAttached("RowColumn", typeof(string), typeof(Xamarin.Forms.View), null, defaultBindingMode: BindingMode.OneWay, validateValue: null, propertyChanged: OnRowColumnPropertyChanged);

        public static string GetRowColumn(BindableObject element)
        {
            return (string)element.GetValue(RowColumnProperty);
        }

        public static void SetRowColumn(BindableObject element, string value)
        {
            element.SetValue(RowColumnProperty, value);
        }

        private static void OnRowColumnPropertyChanged(BindableObject obj, object oldValue, object newValue)
        {
            var element = obj as Xamarin.Forms.View;

            if (element != null && newValue != null)
            {
                string rowcolvalue = newValue.ToString().ToLowerInvariant();

                {
                    string[] rowcols = rowcolvalue.Split(_defaultRowColSeparator);
                    for (int i = 0; i < rowcols.Length; i++)
                    {
                        string[] vals = rowcols[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (i == 0)
                        {
                            if (vals.Length == 1) Grid.SetRow(obj, int.Parse(vals[0]));
                            else if (vals.Length == 2)
                            {
                                Grid.SetRow(obj, int.Parse(vals[0]));
                                Grid.SetRowSpan(obj, int.Parse(vals[1]));
                            }
                        }
                        else if (i == 1)
                        {
                            if (vals.Length == 1) Grid.SetColumn(obj, int.Parse(vals[0]));
                            else if (vals.Length == 2)
                            {
                                Grid.SetColumn(obj, int.Parse(vals[0]));
                                Grid.SetColumnSpan(obj, int.Parse(vals[1]));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region methods
        static void RebuildDefinitions(BindableObject d, string newvalue)
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
                                if (i == 0) element.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(parsedNumber, GridUnitType.Absolute) });
                                else if (i == 1) element.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(parsedNumber, GridUnitType.Absolute) });
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
