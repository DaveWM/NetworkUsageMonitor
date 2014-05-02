using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace NetworkUsageMonitor.ViewModels
{
    public class NetworkStatisticsViewModel:INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string InterfaceName { get; set; }
        private int _bytesReceived = 0;
        public decimal MBReceived
        {
            get { return _bytesReceived/1000000M; }
        }
        private int _bytesSent = 0;
        public decimal MBSent
        {
            get { return _bytesSent/1000000M; }
        }
        public NetworkStatisticsViewModel()
        {
            
        }

        private readonly PerformanceCounter _receivedPC;
        private readonly PerformanceCounter _sentPC;
        private const int RefreshInterval = 500;
        private const int Samples = 1;
        public NetworkStatisticsViewModel(string interfaceName)
        {
            InterfaceName = interfaceName;
            _receivedPC = new PerformanceCounter("Network Interface", "Bytes Received/sec", InterfaceName);
            _sentPC = new PerformanceCounter("Network Interface", "Bytes Sent/sec", InterfaceName);
            var t = new Timer { AutoReset = true, Interval = RefreshInterval };
            t.Elapsed += (s,ea) => UpdateStatistics();
            t.Start();
        }
        private void UpdateStatistics()
        {
            float received=0,sent=0;
            for (var i = 0; i < Samples; i++)
            {
                received += _receivedPC.NextValue() * RefreshInterval / (Samples * 1000f);
                OnPropertyChanged("MBReceived");
                sent += _sentPC.NextValue() * RefreshInterval/ (Samples * 1000f);
                OnPropertyChanged("MBSent");
            }
            _bytesReceived += (int)received;
            _bytesSent += (int) sent;
        }

    }
}
