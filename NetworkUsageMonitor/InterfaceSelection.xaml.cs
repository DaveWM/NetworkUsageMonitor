using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NetworkUsageMonitor.ViewModels;

namespace NetworkUsageMonitor
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class InterfaceSelection : Page
    {
        public InterfaceSelection()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (InterfacesListView.SelectedValue != null)
            {
                NavigationService.GetNavigationService(this).Navigate(
                    new ViewStatistics(InterfacesListView.SelectedValue.ToString()));
            }
        }
        }
    }
