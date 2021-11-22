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
    /// Interaction logic for itineraryWindow.xaml
    /// </summary>
    public partial class itineraryWindow : Window
    {
        private Itinerary_AddItineraryItem AddItineraryItem_Window;
        public bool customEvent1_isVisible;

        public itineraryWindow()
        {
            InitializeComponent();
            AddItineraryItem_Window = new Itinerary_AddItineraryItem();
            AddItineraryItem_Window.Hide();

            var customEventButton1 = (Button)this.FindName("AdditionalCustomEvent1");
            customEventButton1.Visibility = Visibility.Collapsed;
        }

        public void UpdateCustomEvents(bool[] events, int[] heights)
        {
            int textboxheight_hour = 21;
            customEvent1_isVisible = events[0];
            for(int i=0; i<events.Length; i++)
            {
                var customEventButton = (Button)this.FindName($"AdditionalCustomEvent{i + 1}");
                var textblockBelow = (TextBlock)this.FindName($"AdditionalCustomEven{i + 1}_TextBlockBelow");
                if (events[i]==true)
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
    }
}
