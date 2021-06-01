using System.Linq;
using Xamarin.Forms;

namespace Jara.Xaml.Control.Extension
{
    public class ProgressView : Grid
    {
        Grid _backdrop;
        ActivityIndicator _activityIndicator;

        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(ProgressView), false, BindingMode.OneWay, propertyChanged: OnIsLoadingChanged);
        public static readonly BindableProperty BackgdropColorProperty = BindableProperty.Create(nameof(BackdropColor), typeof(Color), typeof(ProgressView), Color.FromHex("#1f000000"), BindingMode.OneWay, propertyChanged: BackgdropColorChanged);
        public static readonly BindableProperty ActivityColorProperty = BindableProperty.Create(nameof(ActivityColor), typeof(Color), typeof(ProgressView), Color.FromHex("#FFDD2C28"), BindingMode.OneWay, propertyChanged: ActivityColorChanged);

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        public Color BackdropColor
        {
            get => (Color)GetValue(BackgdropColorProperty);
            set => SetValue(BackgdropColorProperty, value);
        }

        public Color ActivityColor
        {
            get => (Color)GetValue(ActivityColorProperty);
            set => SetValue(ActivityColorProperty, value);
        }

        public static void OnIsLoadingChanged(BindableObject bindable, object oldValye, object newValue)
        {
            var ctl = (ProgressView)bindable;
            if (ctl._backdrop == null) return;
            if (ctl._activityIndicator == null) return;

            var newval = (bool)newValue;
            ctl._backdrop.IsVisible = newval;
            ctl._activityIndicator.IsVisible = newval;
        }

        public static void BackgdropColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctl = (ProgressView)bindable;
            if (ctl._backdrop == null) return;

            var newval = (Color)newValue;
            ctl._backdrop.BackgroundColor = newval;
        }

        public static void ActivityColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctl = (ProgressView)bindable;
            if (ctl._backdrop == null) return;

            var newval = (Color)newValue;
            ctl._activityIndicator.Color = newval;
        }

        public ProgressView()
        {

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var childrens = this.Children.Where(x => x == this);

            if (!childrens.Any())
            {
                Init();
            }
        }

        public void Init()
        {
            _backdrop = new Grid()
            {
                BackgroundColor = this.BackdropColor,
                IsVisible = this.IsLoading,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            _activityIndicator = new ActivityIndicator()
            {
                WidthRequest = 64,
                HeightRequest = 64,
                IsRunning = this.IsLoading,
                IsVisible = this.IsLoading,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Color = this.ActivityColor
            };

            this.Children.Add(_backdrop);
            this.Children.Add(_activityIndicator);
        }
    }
}
