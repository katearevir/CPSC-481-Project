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

namespace trvlApp
{
    /// <summary>
    /// Interaction logic for EventPin.xaml
    /// </summary>
    public partial class EventPin : Page
    {
        private SettingsPage _settingsPage;

        public EventPin(SettingsPage settingsPage)
        {
            InitializeComponent();
            _settingsPage = settingsPage;
        }

        public void BackButton(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        public void settingsNav(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_settingsPage);
        }
    }
}
