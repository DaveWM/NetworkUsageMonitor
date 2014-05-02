using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace NetworkUsageMonitor.ViewModels
{
    public class NetworkInterfacesViewModel : INotifyPropertyChanged
    {
        public List<String> InterfaceNames { get; set; }
        private string _selectedInterface;
        public string SelectedInterface
        {
            get { return _selectedInterface; }
            set
            {
                _selectedInterface = value;
                OnPropertyChanged("SelectedInterface");
            }
        }

        public NetworkInterfacesViewModel()
        {
            InterfaceNames = new PerformanceCounterCategory("Network Interface").GetInstanceNames().ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
