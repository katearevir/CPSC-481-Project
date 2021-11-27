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
    /// Interaction logic for searchBubbleTea.xaml
    /// </summary>
    public partial class searchBubbleTea : Page
    {
        private Page1 _page1;
        private Page2 _page2;
        private SettingsPage _settingsPage;

        public searchBubbleTea(String input, Page1 page1, Page2 page2, SettingsPage settingsPage)
        {
            InitializeComponent();
            _page1 = page1;
            _page2 = page2;
            _settingsPage = settingsPage;

            var SelectedTextbox = (TextBox)this.FindName("Search");
            SelectedTextbox.Text = input;
        }

        Boolean _is_filtered_food = false;

        private void Button_Click_Foods(object sender, RoutedEventArgs e)
        {
            if (_is_filtered_food == true)
            {
                food_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/restau_filter.png")));
                _is_filtered_food = false;
                food_3.Visibility = Visibility.Visible;
                food_4.Visibility = Visibility.Visible;
            }
            else
            {
                food_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/restau_filter_hidden.png")));
                _is_filtered_food = true;
                food_3.Visibility = Visibility.Hidden;
                food_4.Visibility = Visibility.Hidden;
            }
        }

        private void NavigatePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_page2);
        }

        public void settingsNav(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_settingsPage);
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("Search");
            if (SelectedTextbox.Text == "")
            {
                NavigationService.Navigate(_page1);
            }
        }

    }
}
