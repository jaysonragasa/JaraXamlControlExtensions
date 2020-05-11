using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}