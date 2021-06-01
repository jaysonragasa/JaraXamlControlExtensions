using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XamTest
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        string _title = "Hello Xamarin";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyChanged("Title");
            }
        }

        bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set { if (_isBusy != value) { _isBusy = value; NotifyChanged(); } }
        }

        public ViewModelMainPage()
        {
            this.IsBusy = true;

            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.IsBusy = false;
                });
                
                return false;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}