using System;
using Xamarin.Forms;

namespace Jara.Xaml.Control.Extension
{
    public class TextEx
    {
        #region TextBlock
        public static readonly BindableProperty TextLineProperty = BindableProperty.CreateAttached("TextLine", typeof(string), typeof(Span), "\r\n", defaultBindingMode: BindingMode.TwoWay, validateValue: null, propertyChanged: OnTextLinePropertyChanged);

        public static string GetTextLine(BindableObject element)
        {
            return (string)element.GetValue(TextLineProperty);
        }

        public static void SetTextLine(BindableObject element, string value)
        {
            element.SetValue(TextLineProperty, value);
        }

        private static void OnTextLinePropertyChanged(BindableObject obj, object oldValue, object newValue)
        {
            var element = obj as Span;

            if (element != null && newValue != null)
            {
                string newText = NewText(newValue.ToString());

                element.Text = $"{newText}";
            }
        }
        #endregion

        #region Span
        public static readonly BindableProperty SpanLineProperty = BindableProperty.CreateAttached("SpanLine", typeof(string), typeof(Span), "\r\n", defaultBindingMode: BindingMode.TwoWay, validateValue: null, propertyChanged: OnSpanLinePropertyChanged);

        public static string GetSpanLine(BindableObject element)
        {
            return (string)element.GetValue(SpanLineProperty);
        }

        public static void SetSpanLine(BindableObject element, string value)
        {
            element.SetValue(SpanLineProperty, value);
        }

        private static void OnSpanLinePropertyChanged(BindableObject obj, object oldValue, object newValue)
        {
            var element = obj as Span;

            if (element != null && newValue != null)
            {
                string newText = NewText(newValue.ToString());

                element.Text = $"\n{newText}";
            }
        }
        #endregion

        static string NewText(string newValue)
        {
            string[] texts = newValue.Split(new string[] { "\\n" }, StringSplitOptions.None);

            string newText = texts.Length > 1 ? string.Join("\r\n", texts) : newValue;

            return newText;
        }
    }
}
