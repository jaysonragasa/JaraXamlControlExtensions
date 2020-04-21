using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace Jara.Xaml.Control.Extension
{
    public class TextEx
    {
        #region TextLine
        public static readonly DependencyProperty TextLineProperty = DependencyProperty.RegisterAttached(
            "TextLine",
            typeof(string),
            typeof(TextBlock),
            new PropertyMetadata("\n", OnTextLinePropertyChanged));

        public static string GetTextLine(DependencyObject element)
        {
            return (string)element.GetValue(TextLineProperty);
        }

        public static void SetTextLine(DependencyObject element, string value)
        {
            element.SetValue(TextLineProperty, value);
        }

        private static void OnTextLinePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var element = d as TextBlock;

            if (element != null)
            {
                string newText = NewText(args.NewValue.ToString());

                element.Text = $"{newText}";
            }
        }
        #endregion

        #region RunLine
        public static readonly DependencyProperty RunLineProperty = DependencyProperty.RegisterAttached(
            "RunLine",
            typeof(string),
            typeof(Run),
            new PropertyMetadata("\n", OnRunLinePropertyChanged));

        public static string GetRunLine(DependencyObject element)
        {
            return (string)element.GetValue(RunLineProperty);
        }

        public static void SetRunLine(DependencyObject element, string value)
        {
            element.SetValue(RunLineProperty, value);
        }

        private static void OnRunLinePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var element = d as Run;

            if (element != null)
            {
                string newText = NewText(args.NewValue.ToString());

                element.Text = $"\n{newText}";
            }
        }
        #endregion

        static string NewText(string newValue)
        {
            string[] texts = newValue.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);

            string newText = texts.Length > 1 ? string.Join("\r\n", texts) : newValue;

            return newText.Trim();
        }
    }
}
