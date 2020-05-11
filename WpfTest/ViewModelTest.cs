using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTest
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        string _title = "Hello WPF NetStandard";
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