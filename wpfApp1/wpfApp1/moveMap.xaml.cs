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
using System.Windows.Shapes;

namespace trvlApp
{
    /// <summary>
    /// Interaction logic for moveMap.xaml
    /// </summary>
    public partial class moveMap : Window
    {
        public moveMap()
        {
            InitializeComponent();
        }
        
        Boolean _is_filtered_attraction = false;
        Boolean _is_filtered_event = false;
        Boolean _is_filtered_food = false;

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
            }
            else
            {
                event_filter.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/events_filter_hidden.png")));
                _is_filtered_event = true;
                event_1.Visibility = Visibility.Hidden;
                event_2.Visibility = Visibility.Hidden;
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
    }
}
