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
    /// Interaction logic for RestaurantPin.xaml
    /// </summary>
    public partial class RestaurantPin : Page
    {
        public RestaurantPin()
        {
            InitializeComponent();
        }

        public void BackButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.RelativeOrAbsolute));
        }

        public void OpenSettingsWindow(object sender, RoutedEventArgs e)
        {
            trvlApp.SettingsWindow objSettingsWindow = new trvlApp.SettingsWindow();
            this.Visibility = Visibility.Hidden; // hiding current window 
            objSettingsWindow.Show();
        }


    }
}
