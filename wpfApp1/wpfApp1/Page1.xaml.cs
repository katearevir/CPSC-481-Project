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

            background.PreviewMouseDown += MapImage_PreviewMouseDown;

            _page1 = this;
            _settingsPage = new SettingsPage();
            _page2 = new Page2(this, _settingsPage);
            _settingsPage.AddItineraryPage(_page2);
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

        UIElement dragObject = null;
        Point offset;

        private bool _isDragging;
        private Point _clickPoint;
        private void MapImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                _isDragging = false;
                //attraction_1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                this.dragObject = sender as UIElement;
                this.offset = e.GetPosition(this.canvas);
                this.offset.Y -= Canvas.GetTop(this.dragObject);
                this.offset.X -= Canvas.GetLeft(this.dragObject);
                this.canvas.CaptureMouse();
            }
            _clickPoint = e.GetPosition(this);
            
        }
        private void CanvasMain_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            if (this.dragObject == null)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(this);
                double distanceX = Math.Abs(_clickPoint.X - currentPosition.X);
                double distanceY = Math.Abs(_clickPoint.Y - currentPosition.Y);
                if (distanceX > 10 || distanceY > 10)
                {
                    _isDragging = true;
                    Console.WriteLine("Dragging");
                    var position = e.GetPosition(sender as IInputElement);
                    Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
                    Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
                }
            }
            /*
            // in order to prevent the object from leaving the window, set the bounds with this condition
            // uses the canvas actual/current height and width to determine the bounds, even if the window will be resized
            if (e.GetPosition(sender as IInputElement).X < canvas.ActualWidth - 50 && e.GetPosition(sender as IInputElement).Y < canvas.ActualHeight - 50 && e.GetPosition(sender as IInputElement).X > 50 && e.GetPosition(sender as IInputElement).Y > 50)
            {
                var position = e.GetPosition(sender as IInputElement);
                Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
                Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
            }
            */
            

        }

        private void CanvasMain_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
            }
            this.dragObject = null;
            this.canvas.ReleaseMouseCapture();
        }

            private void Search_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("Search");
            if (SelectedTextbox.Text == "Search")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("Search");
            if (SelectedTextbox.Text.ToLower() == "bubble tea")
            {
                attraction_1.Visibility = Visibility.Hidden;
                attraction_2.Visibility = Visibility.Hidden;
                event_1.Visibility = Visibility.Hidden;
                event_2.Visibility = Visibility.Hidden;
                event_3.Visibility = Visibility.Hidden;
                food_1.Visibility = Visibility.Hidden;
                food_2.Visibility = Visibility.Hidden;
            }
            if (SelectedTextbox.Text == "")
            {
                SelectedTextbox.Text = "Search";
                
                if (_is_filtered_attraction == false)
                {
                    attraction_1.Visibility = Visibility.Visible;
                    attraction_2.Visibility = Visibility.Visible;
                }
                else
                {
                    attraction_1.Visibility = Visibility.Hidden;
                    attraction_2.Visibility = Visibility.Hidden;
                }
                
                if (_is_filtered_event == false)
                {

                    event_1.Visibility = Visibility.Visible;
                    event_2.Visibility = Visibility.Visible;
                    event_3.Visibility = Visibility.Visible;
                }
                else
                {
                    event_1.Visibility = Visibility.Hidden;
                    event_2.Visibility = Visibility.Hidden;
                    event_3.Visibility = Visibility.Hidden;
                }

                if (_is_filtered_food == false)
                {
                    food_1.Visibility = Visibility.Visible;
                    food_2.Visibility = Visibility.Visible;
                    food_3.Visibility = Visibility.Visible;
                    food_4.Visibility = Visibility.Visible;
                }
                else
                {
                    food_1.Visibility = Visibility.Hidden;
                    food_2.Visibility = Visibility.Hidden;
                    food_3.Visibility = Visibility.Hidden;
                    food_4.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Enter_Key_Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var SelectedTextbox = (TextBox)this.FindName("Search");
                if (SelectedTextbox.Text.ToLower() == "bubble tea")
                {
                    attraction_1.Visibility = Visibility.Hidden;
                    attraction_2.Visibility = Visibility.Hidden;
                    event_1.Visibility = Visibility.Hidden;
                    event_2.Visibility = Visibility.Hidden;
                    event_3.Visibility = Visibility.Hidden;
                    food_1.Visibility = Visibility.Hidden;
                    food_2.Visibility = Visibility.Hidden;
                }
                if (SelectedTextbox.Text == "")
                {
                    SelectedTextbox.Text = "Search";

                    if (_is_filtered_attraction == false)
                    {
                        attraction_1.Visibility = Visibility.Visible;
                        attraction_2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        attraction_1.Visibility = Visibility.Hidden;
                        attraction_2.Visibility = Visibility.Hidden;
                    }

                    if (_is_filtered_event == false)
                    {

                        event_1.Visibility = Visibility.Visible;
                        event_2.Visibility = Visibility.Visible;
                        event_3.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        event_1.Visibility = Visibility.Hidden;
                        event_2.Visibility = Visibility.Hidden;
                        event_3.Visibility = Visibility.Hidden;
                    }

                    if (_is_filtered_food == false)
                    {
                        food_1.Visibility = Visibility.Visible;
                        food_2.Visibility = Visibility.Visible;
                        food_3.Visibility = Visibility.Visible;
                        food_4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        food_1.Visibility = Visibility.Hidden;
                        food_2.Visibility = Visibility.Hidden;
                        food_3.Visibility = Visibility.Hidden;
                        food_4.Visibility = Visibility.Hidden;
                    }
                }
            }
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

        private void CustomEvent2Pin_Click(object sender, RoutedEventArgs e)
        {
            var AddItineraryItem_Window = new Itinerary_AddItineraryItem(_page2);
            AddItineraryItem_Window.MainWindowIsMapPage = true;
            AddItineraryItem_Window.Show();
            //if we were to do stuff with this we should make an object with this info and use that instead, but this is just to show that it works in the meantime.
            AddItineraryItem_Window.Set_All_Fields("Chinatown Shopping", "Chinatown, Calgary, AB", "12:00", "12:50", Itinerary_AddItineraryItem.TimeEnum.PM,
                Itinerary_AddItineraryItem.TimeEnum.PM, Itinerary_AddItineraryItem.LocationTypeEnum.PlaceOfInterest, "Meet up & explore mall for some quick shopping. Also restaurants in/nearby.");
        }
    }
}
