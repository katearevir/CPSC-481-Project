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
    /// Interaction logic for Itinerary_AddItineraryItem.xaml
    /// </summary>
    public partial class Itinerary_AddItineraryItem : Window
    {
        public enum TimeEnum
        {
            AM,
            PM
        }
        
        public enum LocationTypeEnum
        {
            Restaurant,
            Event,
            PlaceOfInterest
        }

        public itineraryWindow parentWindow;

        public Itinerary_AddItineraryItem()
        {
            InitializeComponent();
        }

        public Itinerary_AddItineraryItem(itineraryWindow itineraryWindow)
        {
            InitializeComponent();
            parentWindow = itineraryWindow;
        }

        public void Set_All_Fields(string name, string location, string timeStart, string timeEnd, TimeEnum timeStartDropdown, TimeEnum timeEndDropdown,
            LocationTypeEnum locationType, string notes)
        {
            var nameTextbox = (TextBox)this.FindName("NameTextBox");
            nameTextbox.Text = name;
            nameTextbox.Foreground = Brushes.Black;
            var locationTextbox = (TextBox)this.FindName("LocationTextBox");
            locationTextbox.Text = location;
            locationTextbox.Foreground = Brushes.Black;
            var timeStartTextbox = (TextBox)this.FindName("TimeStartTextBox");
            timeStartTextbox.Text = timeStart;
            timeStartTextbox.Foreground = Brushes.Black;
            var timeEndTextbox = (TextBox)this.FindName("TimeEndTextBox");
            timeEndTextbox.Text = timeEnd;
            timeEndTextbox.Foreground = Brushes.Black;
            var notesTextbox = (TextBox)this.FindName("NotesTextBox");
            notesTextbox.Text = notes;
            var timeStartDD = (ComboBox)this.FindName("TimeStartDropdown");
            timeStartDD.SelectedIndex = (int)timeStartDropdown;
            var timeEndDD = (ComboBox)this.FindName("TimeEndDropdown");
            timeEndDD.SelectedIndex = (int)timeEndDropdown;
            var locationTypeDD = (ComboBox)this.FindName("LocationTypeDropDown");
            locationTypeDD.SelectedIndex = (int)locationType;
        }

        private void NameTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("NameTextBox");
            if (SelectedTextbox.Text == "<Name>")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void LocationTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("LocationTextBox");
            if (SelectedTextbox.Text == "<Location>")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void TimeStartTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("TimeStartTextBox");
            if (SelectedTextbox.Text == "hr:mn")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void TimeEndTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("TimeEndTextBox");
            if (SelectedTextbox.Text == "hr:mn")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void NameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("NameTextBox");
            if (SelectedTextbox.Text == "")
            {
                SelectedTextbox.Text = "<Name>";
                SelectedTextbox.Foreground = Brushes.Gainsboro;
            }
        }

        private void LocationTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("LocationTextBox");
            if (SelectedTextbox.Text == "")
            {
                SelectedTextbox.Text = "<Location>";
                SelectedTextbox.Foreground = Brushes.Gainsboro;
            }
        }

        private void TimeStartTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("TimeStartTextBox");
            if (SelectedTextbox.Text == "")
            {
                SelectedTextbox.Text = "hr:mn";
                SelectedTextbox.Foreground = Brushes.Gainsboro;
            }
        }

        private void TimeEndTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var SelectedTextbox = (TextBox)this.FindName("TimeEndTextBox");
            if (SelectedTextbox.Text == "")
            {
                SelectedTextbox.Text = "hr:mn";
                SelectedTextbox.Foreground = Brushes.Gainsboro;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Only make custom event 1 visible if name is exactly equal to Mcdonalds
            //TODO: Also add in the code for an error popup here :)
            var SelectedTextbox = (TextBox)this.FindName("NameTextBox");
            bool[] events = new bool[] { false }; //list of events
            int[] heights = new int[] { 21 };
            if (SelectedTextbox.Text == "Mcdonalds")
            {
                events[0] = true;
                parentWindow.UpdateCustomEvents(events, heights);
            }
            else if (SelectedTextbox.Text =="<Name>")
            {
                return;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Open window to confirm deletion of the item
            var SelectedTextbox = (TextBox)this.FindName("NameTextBox");
            if (SelectedTextbox.Text != "<Name>")
            {
                ItineraryItem_DeleteConfirmation deleteConfirmationWindow = new ItineraryItem_DeleteConfirmation(this, SelectedTextbox.Text);
                deleteConfirmationWindow.Show();
            }
        }

        public void DeleteItineraryItem(string name)
        {
            //Only "delete" (hide it from view ;D) the custom event 1 if name was exactly equal to Mcdonalds && it was confirmed.
            bool[] events = new bool[] { parentWindow.customEvent1_isVisible }; //list of events - note, previous states of custom events is needed.
            int[] heights = new int[] { 21 };
            if (name == "Mcdonalds")
            {
                events[0] = false;
                parentWindow.UpdateCustomEvents(events, heights);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
