using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Page2 parentWindow;

        public Itinerary_AddItineraryItem()
        {
            InitializeComponent();
        }

        public Itinerary_AddItineraryItem(Page2 itineraryWindow)
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

            var viewPinButton = (Button)this.FindName("ViewPinButton");
            viewPinButton.IsEnabled = true;
        }

        private void NameTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

            var SelectedTextbox = (TextBox)this.FindName("NameTextBox");
            if (SelectedTextbox.Text == "<Name>")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void LocationTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

            var SelectedTextbox = (TextBox)this.FindName("LocationTextBox");
            if (SelectedTextbox.Text == "<Location>")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
                var viewPinButton = (Button)this.FindName("ViewPinButton");
                viewPinButton.IsEnabled = true;

            }
        }

        // WARNING: Bug if you type in 1:23, then select between the digits 2 & 3 and add another number 
        // WARNING: Bug if you type in "a" "c" or "v" -> will be visible. can use ctrl+c/ctrl+v/ctrl+a but make sure ctrl is pressed first!!!!
        private void TimeStartTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

            var SelectedTextbox = (TextBox)this.FindName("TimeStartTextBox");
            if (e.Key >= Key.D0 && e.Key <= Key.D9 && (SelectedTextbox.Text.Length < 5 || SelectedTextbox.Text == "hr:mn")) ; // it`s number
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 && (SelectedTextbox.Text.Length < 5 || SelectedTextbox.Text == "hr:mn")) ; // it`s number
            else if (e.Key == Key.OemSemicolon) // it's a semicolon
            {
                if (SelectedTextbox.Text == "1" || SelectedTextbox.Text == "2" || SelectedTextbox.Text == "3" || SelectedTextbox.Text == "4" ||
                    SelectedTextbox.Text == "5" || SelectedTextbox.Text == "6" || SelectedTextbox.Text == "7" || SelectedTextbox.Text == "8" ||
                    SelectedTextbox.Text == "9" || SelectedTextbox.Text == "10" || SelectedTextbox.Text == "11" || SelectedTextbox.Text == "12")
                {

                    SelectedTextbox.AppendText(":");
                    SelectedTextbox.CaretIndex += 1;
                }
                e.Handled = true;
                return;
            }
            else if (e.Key == Key.Escape || e.Key == Key.Tab || e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.LeftCtrl ||
                e.Key == Key.LWin || e.Key == Key.LeftAlt || e.Key == Key.RightAlt || e.Key == Key.RightCtrl || e.Key == Key.RightShift ||
                e.Key == Key.Left || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Right || e.Key == Key.Return || e.Key == Key.Delete ||
                e.Key == Key.System || e.Key == Key.C || e.Key == Key.V || e.Key == Key.A || e.Key == Key.Back) ; // it`s a system key (add other key here if you want to allow)
            else {
                e.Handled = true; // the key will sappressed
                return;
            }

            if (SelectedTextbox.Text == "hr:mn")
            {
                SelectedTextbox.Foreground = Brushes.Black;
                SelectedTextbox.Text = "";
            }
        }

        private void TimeEndTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

            var SelectedTextbox = (TextBox)this.FindName("TimeEndTextBox");
            if (e.Key >= Key.D0 && e.Key <= Key.D9 && (SelectedTextbox.Text.Length < 5 || SelectedTextbox.Text == "hr:mn")) ; // it`s number
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 && (SelectedTextbox.Text.Length < 5 || SelectedTextbox.Text == "hr:mn")) ; // it`s number
            else if (e.Key == Key.OemSemicolon) // it's a semicolon
            {
                if (SelectedTextbox.Text == "1" || SelectedTextbox.Text == "2" || SelectedTextbox.Text == "3" || SelectedTextbox.Text == "4" ||
                    SelectedTextbox.Text == "5" || SelectedTextbox.Text == "6" || SelectedTextbox.Text == "7" || SelectedTextbox.Text == "8" ||
                    SelectedTextbox.Text == "9" || SelectedTextbox.Text == "10" || SelectedTextbox.Text == "11" || SelectedTextbox.Text == "12")
                {

                    SelectedTextbox.AppendText(":");
                    SelectedTextbox.CaretIndex += 1;
                }
                e.Handled = true;
                return;
            }
            else if (e.Key == Key.Escape || e.Key == Key.Tab || e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.LeftCtrl ||
                e.Key == Key.LWin || e.Key == Key.LeftAlt || e.Key == Key.RightAlt || e.Key == Key.RightCtrl || e.Key == Key.RightShift ||
                e.Key == Key.Left || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Right || e.Key == Key.Return || e.Key == Key.Delete ||
                e.Key == Key.System || e.Key == Key.C || e.Key == Key.V || e.Key == Key.A || e.Key == Key.Back) ; // it`s a system key (add other key here if you want to allow)
            else
            {
                e.Handled = true; // the key will sappressed
                return;
            }

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
                var viewPinButton = (Button)this.FindName("ViewPinButton");
                viewPinButton.IsEnabled = false;
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

        private bool NoErrors()
        {
            bool noError = true;
            string message = "";
            var nameTextbox = (TextBox)this.FindName("NameTextBox");
            if (nameTextbox.Text == "<Name>")
            {
                message += "Please name the itinerary item. ";
                noError = false;
            }
            var locationTextbox = (TextBox)this.FindName("LocationTextBox");
            if (locationTextbox.Text == "<Location>")
            {
                message += "Please enter any location. A pin will appear on the map if it is a valid map location. ";
                noError = false;
            }
            var timeStartTextbox = (TextBox)this.FindName("TimeStartTextBox");
            string[] timeStartArray = Regex.Split(timeStartTextbox.Text, ":");
            int startHours = 0;
            int startMinutes = 0;
            bool startTimeFieldIsValid = true;
            bool endTimeFieldIsValid = true;
            if (timeStartArray.Length != 2)
            {
                startTimeFieldIsValid = false;
            }
            else
            {
                bool successfulhours = int.TryParse(timeStartArray[0], out startHours);
                bool successfulminutes = int.TryParse(timeStartArray[1], out startMinutes);
                if (!successfulhours)
                {
                    startTimeFieldIsValid = false;
                }
                else if (!successfulminutes)
                {
                    startTimeFieldIsValid = false;
                }
                else if (startHours < 1 || startHours > 12 || startMinutes < 0 || startMinutes > 59)
                {
                    startTimeFieldIsValid = false;
                }
            }
            var timeEndTextbox = (TextBox)this.FindName("TimeEndTextBox");
            string[] timeEndArray = Regex.Split(timeEndTextbox.Text, ":");
            int endHours = 0;
            int endMinutes = 0;
            if (timeEndArray.Length != 2)
            {
                endTimeFieldIsValid = false;
            }
            else
            {
                bool successfulhours = int.TryParse(timeEndArray[0], out endHours);
                bool successfulminutes = int.TryParse(timeEndArray[1], out endMinutes);
                if (!successfulhours)
                {
                    endTimeFieldIsValid = false;
                }
                else if (!successfulminutes)
                {
                    endTimeFieldIsValid = false;
                }
                else if (endHours < 1 || endHours > 12 || endMinutes < 0 || endMinutes > 59)
                {
                    endTimeFieldIsValid = false;
                }
            }

            if (!startTimeFieldIsValid && !endTimeFieldIsValid)
            {
                message += "Please enter the ending time of the itinerary item, from 1:00 to 12:59. ";
                noError = false;
            }
            else if (!startTimeFieldIsValid && endTimeFieldIsValid)
            {
                message += "Please enter the starting time of the itinerary item, from 1:00 to 12:59. ";
                noError = false;
            }
            else if (startTimeFieldIsValid && !endTimeFieldIsValid)
            {
                message += "Please enter the ending time of the itinerary item, from 1:00 to 12:59. ";
                noError = false;
            }

            var timeStartDD = (ComboBox)this.FindName("TimeStartDropdown");
            if(timeStartDD.SelectedIndex == -1)
            {
                message += "Please select AM or PM for the starting time of the itinerary item. ";
                noError = false;
            }
            var timeEndDD = (ComboBox)this.FindName("TimeEndDropdown");
            if(timeEndDD.SelectedIndex == -1)
            {
                message += "Please select AM or PM for the ending time of the itinerary item. ";
                noError = false;
            }
            // Code to make the time make sense:
            if(startTimeFieldIsValid && endTimeFieldIsValid && timeStartDD.SelectedIndex!=-1 && timeEndDD.SelectedIndex!=-1 && timeStartDD.SelectedIndex == timeEndDD.SelectedIndex)
            {
                // if both are AM or PM:
                if(startHours!=12 && startHours>endHours)
                {
                    message += "The starting time should be earlier than the ending time. ";
                    noError = false;
                }
                else if (startHours == endHours && startMinutes>endMinutes)
                {
                    message += "The starting time should be earlier than the ending time. ";
                    noError = false;
                }
                else if (startHours == endHours && startMinutes == endMinutes)
                {
                    message += "You cannot schedule an itinerary item for zero minutes. ";
                    noError = false;
                }
            }
            else if (startTimeFieldIsValid && endTimeFieldIsValid && timeStartDD.SelectedIndex == 1 && timeEndDD.SelectedIndex == 0)
            {
                //what if 10pm -> 1am? Not allowed since it goes into another itinerary time :P
                message += "The starting time should be earlier than the ending time. You may only plan for one day's itinerary, from 12:00 AM to 11:59 PM. ";
                noError = false;
            }
            var locationTypeDD = (ComboBox)this.FindName("LocationTypeDropDown");
            if(locationTypeDD.SelectedIndex == -1)
            {
                message += "Please specify the type of location; Restaurant, Event, or Place of Interest.";
                noError = false;
            }

            if(!noError)
            {
                ItineraryItem_Error errorWindow = new ItineraryItem_Error(message);
                errorWindow.Show();
            }

            return noError;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Only make custom event 1 visible if name is exactly equal to Mcdonalds
            if(!NoErrors())
            {
                return;
            }
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Visible;
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

        private void TimeStartDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

        }

        private void TimeEndDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

        }

        private void LocationTypeDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

        }

        private void NotesTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var savedLabel = (Label)this.FindName("SavedLabel");
            savedLabel.Visibility = Visibility.Collapsed;

        }


        public bool MainWindowIsMapPage = false;
        private void ViewPinButton_Click(object sender, RoutedEventArgs e)
        {
            var locationTextbox = (TextBox)this.FindName("LocationTextBox");

            if (locationTextbox.Text.Contains(".")) ;
            else if (!locationTextbox.Text.Contains("Calgary"))
            {
                ItineraryItem_Error errorWindow = new ItineraryItem_Error(
                    $"The location '{locationTextbox.Text}' could not be found in Calgary.");
                errorWindow.Show();
            }
            else if(locationTextbox.Text != "Chinatown, Calgary, AB")
            {
                ItineraryItem_Error errorWindow = new ItineraryItem_Error(
                    $"Could not find pin on map. Please make sure {locationTextbox.Text} can be found on Google Maps.");
                errorWindow.Show();
            }

            // Somehow navigate to page & center on green pin (Any green pin is fine)
            if (!MainWindowIsMapPage)
            {
                parentWindow.NavigatePage(new object(), new RoutedEventArgs());
            }
            //somehow move map.
        }

        private void GetDirectionsButton_Click(object sender, RoutedEventArgs e)
        {
            var locationTextbox = (TextBox)this.FindName("LocationTextBox");

            if (locationTextbox.Text == "<Location>")
                return;

            if (locationTextbox.Text.Contains(".")) ;
            else if (!locationTextbox.Text.Contains("Calgary"))
            {
                ItineraryItem_Error errorWindow = new ItineraryItem_Error(
                    $"The location '{locationTextbox.Text}' could not be found in Calgary.");
                errorWindow.Show();
            }
            else if (locationTextbox.Text != "Chinatown, Calgary, AB")
            {
                ItineraryItem_Error errorWindow = new ItineraryItem_Error(
                    $"Please make sure {locationTextbox.Text} can be found on Google Maps.");
                errorWindow.Show();
            }
        }
    }
}
