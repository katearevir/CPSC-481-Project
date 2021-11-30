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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private trvlApp.Page1 _page1;
        private SettingsPage _settingsPage;
        private Itinerary_AddItineraryItem AddItineraryItem_Window;
        public bool customEvent1_isVisible;
        public String searchInput;

        public Page2(trvlApp.Page1 page1, SettingsPage settingsPage)
        {
            InitializeComponent();
            _page1 = page1;
            _settingsPage = settingsPage; 
            AddItineraryItem_Window = new Itinerary_AddItineraryItem();
            AddItineraryItem_Window.Hide();

            var customEventButton1 = (Button)this.FindName("AdditionalCustomEvent1");
            customEventButton1.Visibility = Visibility.Collapsed;
        }

        public void NavigatePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_page1);
        }

        public void settingsNav(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_settingsPage);
        }


        public void UpdateCustomEvents(bool[] events, int[] heights)
        {
            int textboxheight_hour = 21;
            customEvent1_isVisible = events[0];
            for (int i = 0; i < events.Length; i++)
            {
                var customEventButton = (Button)this.FindName($"AdditionalCustomEvent{i + 1}");
                var textblockBelow = (TextBlock)this.FindName($"AdditionalCustomEven{i + 1}_TextBlockBelow");
                if (events[i] == true)
                {
                    //show event
                    customEventButton.Visibility = Visibility.Visible;
                    textblockBelow.Height = textboxheight_hour - heights[i];
                }
                else
                {
                    //hide event
                    customEventButton.Visibility = Visibility.Collapsed;
                    textblockBelow.Height = textboxheight_hour + heights[i];
                }
            }
        }

        public void EnableSharedTab()
        {   
            // Call this in settings page when successful import
            var sharedTab = (TabItem)this.FindName("SharedTab");
            sharedTab.IsEnabled = true;

            var sharedTab_Empty = (TabItem)this.FindName("SharedTab_Empty");
            sharedTab_Empty.IsEnabled = true;
        }

        public void DisableSharedTab()
        {
            //Probably useless function - just in case we want to ever disable the shared tab after enabling it.
            var sharedTab = (TabItem)this.FindName("SharedTab");
            sharedTab.IsEnabled = false;

            var sharedTab_Empty = (TabItem)this.FindName("SharedTab_Empty");
            sharedTab_Empty.IsEnabled = false;

            TabControl tabControl = (TabControl)this.FindName("TabControl");
            var personalTab = (TabItem)this.FindName("PersonalTab");
            tabControl.SelectedItem = personalTab;
            var addItineraryItem_Button = (Button)this.FindName("AddItineraryItem_Button");
            addItineraryItem_Button.Visibility = Visibility.Visible;

            TabControl tabControl_Empty = (TabControl)this.FindName("TabControl_Empty");
            var personalTab_Empty = (TabItem)this.FindName("PersonalTab_Empty");
            tabControl_Empty.SelectedItem = personalTab_Empty;
            var addItineraryItem_Button_Empty = (Button)this.FindName("AddItineraryItem_Button_Empty");
            addItineraryItem_Button_Empty.Visibility = Visibility.Visible;
        }

        public void ShowSharedTab()
        {
            if(day == 0)
            {
                TabControl tabControl = (TabControl)this.FindName("TabControl");
                var sharedTab = (TabItem)this.FindName("SharedTab");
                tabControl.SelectedItem = sharedTab;
                var addItineraryItem_Button_Empty = (Button)this.FindName("AddItineraryItem_Button");
                addItineraryItem_Button_Empty.Visibility = Visibility.Collapsed;
            }
            else
            {
                TabControl tabControl = (TabControl)this.FindName("TabControl_Empty");
                var sharedTab = (TabItem)this.FindName("SharedTab_Empty");
                tabControl.SelectedItem = sharedTab;
                var addItineraryItem_Button_Empty = (Button)this.FindName("AddItineraryItem_Button_Empty");
                addItineraryItem_Button_Empty.Visibility = Visibility.Collapsed;
            }
        }

        private void AddItineraryItem_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddItineraryItem_Window = new Itinerary_AddItineraryItem(this);
            AddItineraryItem_Window.Show();
        }

        private void AdditionalCustomEvent1_Click(object sender, RoutedEventArgs e)
        {
            AddItineraryItem_Window = new Itinerary_AddItineraryItem(this);
            AddItineraryItem_Window.Show();
            //if we were to do stuff with this we should make an object with this info and use that instead, but this is just to show that it works in the meantime.
            AddItineraryItem_Window.Set_All_Fields("Mcdonalds", "1422 17 Ave SW, Calgary, AB T2T 0C3", "2:00", "2:50", Itinerary_AddItineraryItem.TimeEnum.PM,
                Itinerary_AddItineraryItem.TimeEnum.PM, Itinerary_AddItineraryItem.LocationTypeEnum.Restaurant, "Should have enough time for a quick snack.");
        }

        private void CustomEvent2_Click(object sender, RoutedEventArgs e)
        {
            AddItineraryItem_Window = new Itinerary_AddItineraryItem(this);
            AddItineraryItem_Window.Show();
            //if we were to do stuff with this we should make an object with this info and use that instead, but this is just to show that it works in the meantime.
            AddItineraryItem_Window.Set_All_Fields("Chinatown Shopping", "Chinatown, Calgary, AB", "12:00", "12:50", Itinerary_AddItineraryItem.TimeEnum.PM,
                Itinerary_AddItineraryItem.TimeEnum.PM, Itinerary_AddItineraryItem.LocationTypeEnum.PlaceOfInterest, "Meet up & explore mall for some quick shopping. Also restaurants in/nearby.");
        }

        private void SharedTab_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var addItineraryItemButton = (Button)this.FindName("AddItineraryItem_Button");
            addItineraryItemButton.Visibility = Visibility.Hidden;
        }

        private void PersonalTab_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var addItineraryItemButton = (Button)this.FindName("AddItineraryItem_Button");
            addItineraryItemButton.Visibility = Visibility.Visible;
        }

        private void SharedTab_Empty_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var addItineraryItemButton = (Button)this.FindName("AddItineraryItem_Button_Empty");
            addItineraryItemButton.Visibility = Visibility.Hidden;
        }

        private void PersonalTab_Empty_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var addItineraryItemButton = (Button)this.FindName("AddItineraryItem_Button_Empty");
            addItineraryItemButton.Visibility = Visibility.Visible;
        }

        private int day = 0;

        private bool IsSharedTabSelected()
        {
            TabControl tabControl = (TabControl)this.FindName("TabControl");
            if (tabControl.SelectedItem == null)
                return false;
            if (((TabItem)tabControl.SelectedItem).Name == "SharedTab")
                return true;
            return false;
        }

        private bool IsSharedTab_EmptySelected()
        {
            TabControl tabControl = (TabControl)this.FindName("TabControl_Empty");
            if (tabControl.SelectedItem == null)
                return false;
            if (((TabItem)tabControl.SelectedItem).Name == "SharedTab_Empty")
                return true;
            return false;
        }

        private void NextDateButton_Click(object sender, RoutedEventArgs e)
        {
            var empty_StackPanel = (StackPanel)this.FindName("ItineraryStackPanel_Empty");
            var currentDay_StackPanel = (StackPanel)this.FindName("ItineraryStackPanel_CurrentDay");
            var addItineraryItem_Button_Empty = (Button)this.FindName("AddItineraryItem_Button_Empty");
            var addItineraryItem_Button = (Button)this.FindName("AddItineraryItem_Button");

            var calendarDayButton = (Button)this.FindName("CalendarButton");
            if(day == 0) // current day
            {
                day = 1; // future day
                empty_StackPanel.Visibility = Visibility.Visible;
                if(!IsSharedTab_EmptySelected())
                    addItineraryItem_Button_Empty.Visibility = Visibility.Visible;
                addItineraryItem_Button.Visibility = Visibility.Collapsed;
                currentDay_StackPanel.Visibility = Visibility.Collapsed;
                calendarDayButton.Content = new TextBlock
                {
                    Text = "    Tuesday\nSept 28, 2021",
                    TextWrapping = TextWrapping.Wrap
                };
            } 
            else if(day == -1) // past day
            {
                day = 0; // current day
                empty_StackPanel.Visibility = Visibility.Collapsed;
                addItineraryItem_Button_Empty.Visibility = Visibility.Collapsed;
                if(!IsSharedTabSelected())
                    addItineraryItem_Button.Visibility = Visibility.Visible;
                currentDay_StackPanel.Visibility = Visibility.Visible;
                calendarDayButton.Content = new TextBlock
                {
                    Text = "    Monday\nSept 27, 2021",
                    TextWrapping = TextWrapping.Wrap
                };
            } 
            else if(day == 1) //future day
            {
                day = 2; // t+2
                empty_StackPanel.Visibility = Visibility.Visible;
                if(!IsSharedTab_EmptySelected())
                    addItineraryItem_Button_Empty.Visibility = Visibility.Visible;
                addItineraryItem_Button.Visibility = Visibility.Collapsed;
                currentDay_StackPanel.Visibility = Visibility.Collapsed;
                calendarDayButton.Content = new TextBlock
                {
                    Text = "  Wednesday\nSept 29, 2021",
                    TextWrapping = TextWrapping.Wrap
                };
            }
            
        }

        private void PreviousDateButton_Click(object sender, RoutedEventArgs e)
        {
            var empty_StackPanel = (StackPanel)this.FindName("ItineraryStackPanel_Empty");
            var currentDay_StackPanel = (StackPanel)this.FindName("ItineraryStackPanel_CurrentDay");
            var addItineraryItem_Button_Empty = (Button)this.FindName("AddItineraryItem_Button_Empty");
            var addItineraryItem_Button = (Button)this.FindName("AddItineraryItem_Button");
            var calendarDayButton = (Button)this.FindName("CalendarButton");
            if (day == 0) // current day
            {
                day = -1; // past day
                empty_StackPanel.Visibility = Visibility.Visible;
                if(!IsSharedTab_EmptySelected())
                    addItineraryItem_Button_Empty.Visibility = Visibility.Visible;
                addItineraryItem_Button.Visibility = Visibility.Collapsed;
                currentDay_StackPanel.Visibility = Visibility.Collapsed;
                calendarDayButton.Content = new TextBlock
                {
                    Text = "    Sunday\nSept 26, 2021",
                    TextWrapping = TextWrapping.Wrap
                };
            }
            else if (day == 1) // future day
            {
                day = 0; // current day
                empty_StackPanel.Visibility = Visibility.Collapsed;
                addItineraryItem_Button_Empty.Visibility = Visibility.Collapsed;
                if (!IsSharedTabSelected())
                    addItineraryItem_Button.Visibility = Visibility.Visible;
                currentDay_StackPanel.Visibility = Visibility.Visible;
                calendarDayButton.Content = new TextBlock
                {
                    Text = "    Monday\nSept 27, 2021",
                    TextWrapping = TextWrapping.Wrap
                };
            }
            else if (day == 2) // t+2
            {
                day = 1;
                empty_StackPanel.Visibility = Visibility.Visible;
                if(!IsSharedTab_EmptySelected())
                    addItineraryItem_Button_Empty.Visibility = Visibility.Visible;
                addItineraryItem_Button.Visibility = Visibility.Collapsed;
                currentDay_StackPanel.Visibility = Visibility.Collapsed;
                calendarDayButton.Content = new TextBlock
                {
                    Text = "    Tuesday\nSept 28, 2021",
                    TextWrapping = TextWrapping.Wrap
                };
            }
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            var CalendarGrid = (Grid)this.FindName("CalendarGrid");
            CalendarGrid.Visibility = Visibility.Visible;
            var CalendarRectangle = (Rectangle)this.FindName("CalendarRectangle");
            CalendarRectangle.Visibility = Visibility.Visible;
            var ExitCalendar = (Button)this.FindName("ExitCalendar");
            ExitCalendar.Visibility = Visibility.Visible;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = e.AddedItems.Cast<DateTime>().First();
            if(selectedDate == new DateTime(2021, 9, 27))
            {
                return;
            }
            var empty_StackPanel = (StackPanel)this.FindName("ItineraryStackPanel_Empty");
            var currentDay_StackPanel = (StackPanel)this.FindName("ItineraryStackPanel_CurrentDay");
            var addItineraryItem_Button_Empty = (Button)this.FindName("AddItineraryItem_Button_Empty");
            var addItineraryItem_Button = (Button)this.FindName("AddItineraryItem_Button");
            var calendarDayButton = (Button)this.FindName("CalendarButton");
            empty_StackPanel.Visibility = Visibility.Visible; 
            if (!IsSharedTab_EmptySelected())
                addItineraryItem_Button_Empty.Visibility = Visibility.Visible;
            addItineraryItem_Button.Visibility = Visibility.Collapsed;
            currentDay_StackPanel.Visibility = Visibility.Collapsed;
            calendarDayButton.Content = new TextBlock
            {
                Text = "  Wednesday\nSept 29, 2021",
                TextWrapping = TextWrapping.Wrap
            };
            day = 2;
            var CalendarGrid = (Grid)this.FindName("CalendarGrid");
            CalendarGrid.Visibility = Visibility.Collapsed;
            var CalendarRectangle = (Rectangle)this.FindName("CalendarRectangle");
            CalendarRectangle.Visibility = Visibility.Collapsed;
            var ExitCalendar = (Button)this.FindName("ExitCalendar");
            ExitCalendar.Visibility = Visibility.Collapsed;
            var calendar = (Calendar)this.FindName("Calendar");
            calendar.SelectedDate = new DateTime(2021, 9, 27); ;
        }

        private void ExitCalendar_Click(object sender, RoutedEventArgs e)
        {
            var CalendarGrid = (Grid)this.FindName("CalendarGrid");
            CalendarGrid.Visibility = Visibility.Collapsed;
            var CalendarRectangle = (Rectangle)this.FindName("CalendarRectangle");
            CalendarRectangle.Visibility = Visibility.Collapsed;
            var ExitCalendar = (Button)this.FindName("ExitCalendar");
            ExitCalendar.Visibility = Visibility.Collapsed;
        }
    }
}
