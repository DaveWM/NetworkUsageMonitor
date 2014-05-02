using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetworkUsageMonitor
{
    public class NotifyIconClickedCommand:ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Normal;
            Application.Current.MainWindow.Show();
        }

        public event EventHandler CanExecuteChanged;
    }
}
