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
    /// Interaction logic for ItineraryItem_DeleteConfirmation.xaml
    /// </summary>
    public partial class ItineraryItem_DeleteConfirmation : Window
    {
        private Itinerary_AddItineraryItem itinerary_AddItineraryItem;
        private string itineraryName;

        public ItineraryItem_DeleteConfirmation(Itinerary_AddItineraryItem itinerary_AddItineraryItem, string itineraryName)
        {
            InitializeComponent();
            this.itinerary_AddItineraryItem = itinerary_AddItineraryItem;
            this.itineraryName = itineraryName;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            itinerary_AddItineraryItem.DeleteItineraryItem(itineraryName);
            itinerary_AddItineraryItem.Close();
            this.Close();
        }

        private void Deny_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
