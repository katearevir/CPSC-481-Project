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
    /// Interaction logic for AttractionsPin.xaml
    /// </summary>
    public partial class AttractionsPin : Page
    {
        private SettingsPage _settingsPage;
        private Page1 _page1;

        public AttractionsPin(SettingsPage settingsPage, Page1 page1)
        {
            InitializeComponent();
            _settingsPage = settingsPage;
            _page1 = page1;
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

        private void AddItineraryItem_GlenbowMuseum(object sender, RoutedEventArgs e)
        {
            var AddItineraryItem_Window = new Itinerary_AddItineraryItem(_page1._page2);
            AddItineraryItem_Window.MainWindowIsMapPage = true;
            AddItineraryItem_Window.Show();
            //if we were to do stuff with this we should make an object with this info and use that instead, but this is just to show that it works in the meantime.
            AddItineraryItem_Window.Set_All_Fields("Glenbow Museum", "130 9 Ave SE, Calgary, AB T2G 0P3", "9:50", "10:00", Itinerary_AddItineraryItem.TimeEnum.AM,
                Itinerary_AddItineraryItem.TimeEnum.AM, Itinerary_AddItineraryItem.LocationTypeEnum.PlaceOfInterest, "");

            AddItineraryItem_Window.LocationTextBox.IsReadOnly = true;
            AddItineraryItem_Window.NameTextBox.IsReadOnly = true;
            AddItineraryItem_Window.LocationTypeDropDown.IsHitTestVisible = false;

            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            NavigationService.Navigate(_page1._page2);
        }
    }
}
