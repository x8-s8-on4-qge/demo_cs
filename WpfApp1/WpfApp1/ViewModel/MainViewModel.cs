using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfApp1.Command;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public SOAPBtnCommand soapBtnCommand { get; set; }

        public RESTBtnCommand restBtnCommand { get; set; }

        private ObservableCollection<Items> dataItems = new ObservableCollection<Items>();

        public ObservableCollection<Items> DataItems
        {
            get { return dataItems; }
            set
            {
                dataItems = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataItems"));
                }
            }
        }

        public MainViewModel()
        {
            soapBtnCommand = new SOAPBtnCommand(this);
            restBtnCommand = new RESTBtnCommand(this);
        }

        public class Items
        {
            public string? recieveTime { get; set; }
            public string? message { get; set; }
            public string? errorDetail { get; set; }
        }
    }
}
