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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {

        bool keyboardVisible;
        private Page2 ItineraryPage;

        public SettingsPage()
        {
            InitializeComponent();
            EventAlarmStack.Visibility = Visibility.Collapsed;
            BlurredPopUpBackground.Visibility = Visibility.Collapsed;
            KeyboardButton.Visibility = Visibility.Collapsed;
            CodeImportStack.Visibility = Visibility.Collapsed;
            keyboardVisible = false;
            AlertTimingLabel.Content = "sometime";

        }

        public void AddItineraryPage(Page2 page)
        {
            ItineraryPage = page;
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InvertedToggled(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        void toggleKeyboardVisibility()
        {
            if (keyboardVisible)
            {
                KeyboardButton.Visibility = Visibility.Hidden;
                keyboardVisible = false;
            } else
            {
                KeyboardButton.Visibility = Visibility.Visible;
                keyboardVisible = true;
            }
        }

        private void CodeCopied(object sender, RoutedEventArgs e)
        {
            ClipboardLabel.Content = "Copied to Clipboard!";
            KeyboardButton.Visibility = Visibility.Hidden;
            keyboardVisible = false; 
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            KeyboardButton.Visibility = Visibility.Hidden;
        }

        private void ItineraryShareInput(object sender, MouseButtonEventArgs e)
        {
            //this.toggleKeyboardVisibility();
            KeyboardButton.Visibility = Visibility.Visible;
        }

        private void AlarmPopUpOK(object sender, RoutedEventArgs e)
        {
            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            EventAlarmStack.Visibility = Visibility.Hidden;
        }

        private void BlurredPopUpClick(object sender, RoutedEventArgs e)
        {
            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            EventAlarmStack.Visibility = Visibility.Hidden;
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void AlertsToggle(object sender, MouseButtonEventArgs e)
        {
            if (AlertsToggleButton.Toggled1)
            {
                alertText1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                alertText2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                if (FifteenAlert.IsSelected) {
                    AlertTimingLabel.Content = "15 minutes.";
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
                } else if (ThirtyAlert.IsSelected)
                {
                    AlertTimingLabel.Content = "30 minutes.";
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
                } else if (OneHourAlert.IsSelected)
                {
                    AlertTimingLabel.Content = "60 minutes.";
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
                } else if (TwoHoursAlert.IsSelected)
                {
                    AlertTimingLabel.Content = "2 hours.";
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
                } else if (OneDayAlert.IsSelected)
                {
                    AlertTimingLabel.Content = "24 hours.";
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
                } else if (TwoDaysAlert.IsSelected)
                {
                    AlertTimingLabel.Content = "2 days.";
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
                }
                else
                {
                    AlertNotificationLabel.Content = "Please select a time.";
                    AlertTimingLabel.Content = "";
                    // AlertsToggleButton.Toggled = false;
                    AlertsToggleButton.toggleBackgroundDown(sender,e);
                    AlertsToggleButton.toggleCircleButtonDown(sender, e);
                    // AlertsToggleButton.Toggled1 = false;
                    BlurredPopUpBackground.Visibility = Visibility.Visible;
                    EventAlarmStack.Visibility = Visibility.Visible;
         
                }

            } else
            {
                alertText1.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                alertText2.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                //AlertsToggleButton.Toggled1 = false;\
                AlertsToggleButton.Toggled = false; 
                BlurredPopUpBackground.Visibility = Visibility.Collapsed;
                EventAlarmStack.Visibility = Visibility.Collapsed;
            }
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            KeyboardButton.Visibility = Visibility.Visible;

        }

        private void FifteenMinSelected(object sender, RoutedEventArgs e)
        {
            AlertTimingLabel.Content = "15 minutes.";
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            EventAlarmStack.Visibility = Visibility.Visible;
        }

        private void ThirtyMinSelected(object sender, RoutedEventArgs e)
        {
            AlertTimingLabel.Content = "30 minutes.";
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            EventAlarmStack.Visibility = Visibility.Visible;
        }

        private void OneHourSelected(object sender, RoutedEventArgs e)
        {
            AlertTimingLabel.Content = "60 minutes.";
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            EventAlarmStack.Visibility = Visibility.Visible;
        }

        private void TwoHoursSelected(object sender, RoutedEventArgs e)
        {
            AlertTimingLabel.Content = "2 hours.";
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            EventAlarmStack.Visibility = Visibility.Visible;
        }

        private void OneDaySelected(object sender, RoutedEventArgs e)
        {
            AlertTimingLabel.Content = "24 hours.";
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            EventAlarmStack.Visibility = Visibility.Visible;
        }

        private void TwoDaysSelected(object sender, RoutedEventArgs e)
        {
            AlertTimingLabel.Content = "2 days.";
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            EventAlarmStack.Visibility = Visibility.Visible;
        }

        private void AlertTimingComboBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ImportCodeButtonClick(object sender, RoutedEventArgs e)
        {
            EnterCodeLabel.Content = "Code Entered!";
            if (ShareCodeInputBox.Text == "12345") 
            {
                ImportBoxTitle.Content = "Code Success!";
                ImportPopUpLabel.Content = "Code Success, Press OK to go to Itinerary.";
                BlurredPopUpBackground.Visibility = Visibility.Visible;
                CodeImportStack.Visibility = Visibility.Visible;

            } else
            {
                ImportBoxTitle.Content = "Code Failed!";
                ImportPopUpLabel.Content = "The code does not exist, please double check and try again!";
                ReminderLabel.Content = "Reminder: share codes expire after 15 minutes.";
                BlurredPopUpBackground.Visibility = Visibility.Visible;
                CodeImportStack.Visibility = Visibility.Visible;
            }
        }

        private void ImportPopUpOK(object sender, RoutedEventArgs e)
        {
            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            CodeImportStack.Visibility = Visibility.Hidden;
            KeyboardButton.Visibility = Visibility.Hidden;

            ItineraryPage.EnableSharedTab();
            ItineraryPage.ShowSharedTab();
            this.NavigationService.Navigate(ItineraryPage);
        }
    }
}
