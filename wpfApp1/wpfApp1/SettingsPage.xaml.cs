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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            _page1 = page1;
            KeyboardButton.Visibility = Visibility.Collapsed;

        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InvertedToggled(object sender, RoutedEventArgs e)
        {

        }

        private void DarkModeLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void AlertsLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ItineraryInputMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            KeyboardButton.Visibility = Visibility.Visible;
        }
    }
}
