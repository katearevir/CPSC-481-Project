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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Page1 _page1;
        private Page2 _page2;
        private SettingsPage _settingsPage;
        private RestaurantPin _restPin;
        private EventPin _eventPin;
        private AttractionsPin _attractionsPin;

        public Page1()
        {
            InitializeComponent();
            _page1 = this;
            _settingsPage = new SettingsPage();
            _page2 = new Page2(this, _settingsPage);
            _restPin = new RestaurantPin(_settingsPage);
            _eventPin = new EventPin(_settingsPage);
            _attractionsPin = new AttractionsPin(_settingsPage);
        }

        public Page1(trvlApp.Page2 page2)
        {
            InitializeComponent();
            _page2 = page2;
        }

        public Page1(trvlApp.SettingsPage settingsPage)
        {
            InitializeComponent();
            _settingsPage = settingsPage;
        }

        Boolean _is_filtered_attraction = false;
        Boolean _is_filtered_event = false;
        Boolean _is_filtered_food = false;

        public void NavigatePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_page2);
        }

        public void settingsNav(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_settingsPage);
        }

        public void Button_Click_RestPin(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(_restPin);

        }

        public void Button_Click_EventPin(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(_eventPin);

        }

        public void Button_Click_AttractionPin(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(_attractionsPin);

        }

        private void Button_Click_Attractions(object sender, RoutedEventArgs e)
        {
            if (_is_filtered_attraction == true)
            {
                attraction_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/interest_filter.png")));
                _is_filtered_attraction = false;
                attraction_1.Visibility = Visibility.Visible;
                attraction_2.Visibility = Visibility.Visible;
            }
            else
            {
                attraction_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/interest_filter_hidden.png")));
                _is_filtered_attraction = true;
                attraction_1.Visibility = Visibility.Hidden;
                attraction_2.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_Events(object sender, RoutedEventArgs e)
        {
            if (_is_filtered_event == true)
            {
                event_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/events_filter.png")));
                _is_filtered_event = false;
                event_1.Visibility = Visibility.Visible;
                event_2.Visibility = Visibility.Visible;
                event_3.Visibility = Visibility.Visible;
            }
            else
            {
                event_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/events_filter_hidden.png")));
                _is_filtered_event = true;
                event_1.Visibility = Visibility.Hidden;
                event_2.Visibility = Visibility.Hidden;
                event_3.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_Foods(object sender, RoutedEventArgs e)
        {
            if (_is_filtered_food == true)
            {
                food_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/restau_filter.png")));
                _is_filtered_food = false;
                food_1.Visibility = Visibility.Visible;
                food_2.Visibility = Visibility.Visible;
                food_3.Visibility = Visibility.Visible;
                food_4.Visibility = Visibility.Visible;
            }
            else
            {
                food_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/restau_filter_hidden.png")));
                _is_filtered_food = true;
                food_1.Visibility = Visibility.Hidden;
                food_2.Visibility = Visibility.Hidden;
                food_3.Visibility = Visibility.Hidden;
                food_4.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_eve(object sender, RoutedEventArgs e)
        {

        }

    }
}
