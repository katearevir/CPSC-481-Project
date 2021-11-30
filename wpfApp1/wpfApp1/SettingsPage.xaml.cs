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
            ClipboardLabel.Content = "Generated!";
            if (SharingCode.Text == "")
                SharingCode.Text = "123747";
            else if (SharingCode.Text == "123747")
                SharingCode.Text = "542904";
            else if (SharingCode.Text == "542904")
                SharingCode.Text = "102394";
            else if (SharingCode.Text == "102394")
                SharingCode.Text = "123747";
            StopExportingItinerary.Visibility = Visibility.Visible;
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
                AlertTimingComboBox.IsEnabled = true;
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
                AlertTimingComboBox.IsEnabled = false;
                //AlertsToggleButton.Toggled1 = false;\
                AlertsToggleButton.Toggled = false; 
                BlurredPopUpBackground.Visibility = Visibility.Collapsed;
                EventAlarmStack.Visibility = Visibility.Collapsed;
            }
            

        }

        private void soundsToggle(object sender, MouseButtonEventArgs e)
        {
            if (AlarmSoundToggle.Toggled1)
            {
                alarmSoundLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else
            {
                alarmSoundLabel.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));
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

        private bool CodeEnteredCorrectly = false;
        private void ImportCodeButtonClick(object sender, RoutedEventArgs e)
        {
            EnterCodeLabel.Content = "Code Entered!";
            if (ShareCodeInputBox.Text == "123456") 
            {
                ImportBoxTitle.Content = "Code Success!";
                ImportPopUpLabel.Content = new TextBlock
                {
                    Text = "Code Success, Press OK to go to Itinerary.",
                    TextWrapping = TextWrapping.Wrap
                };
                BlurredPopUpBackground.Visibility = Visibility.Visible;
                ImportOKButton.Visibility = Visibility.Visible;
                CodeImportStack.Visibility = Visibility.Visible;
                CodeEnteredCorrectly = true;
                RemoveSharedItinerary.Visibility = Visibility.Visible;
            } else
            {
                ImportBoxTitle.Content = "Code Failed!";
                ImportPopUpLabel.Content = new TextBlock
                {
                    Text = "The code does not exist, please double check and try again!",
                    TextWrapping = TextWrapping.Wrap
                };
                ReminderLabel.Content = "Reminder: share codes expire after 15 minutes.";
                BlurredPopUpBackground.Visibility = Visibility.Visible;
                ImportOKButton.Visibility = Visibility.Visible;
                CodeImportStack.Visibility = Visibility.Visible;
                CodeEnteredCorrectly = false;
            }
        }

        private void ImportPopUpOK(object sender, RoutedEventArgs e)
        {
            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            ImportOKButton.Visibility = Visibility.Collapsed;
            KeyboardButton.Visibility = Visibility.Hidden;
            CodeImportStack.Visibility = Visibility.Collapsed;

            if (CodeEnteredCorrectly)
            {
                ItineraryPage.EnableSharedTab();
                ItineraryPage.ShowSharedTab();
                this.NavigationService.Navigate(ItineraryPage);
            }
        }

        private void PopupCancelSharingButton_Click(object sender, RoutedEventArgs e)
        {
            SharingCode.Text = "";
            ClipboardLabel.Content = "Generate Code";
            StopExportingItinerary.Visibility = Visibility.Collapsed;

            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            ImportOKButton.Visibility = Visibility.Collapsed;
            KeyboardButton.Visibility = Visibility.Hidden;
            CodeImportStack.Visibility = Visibility.Collapsed;

            PopupCancelSharingButton.Visibility = Visibility.Collapsed;
            PopupNoButton.Visibility = Visibility.Collapsed;
            PopupRemoveSharedItineraryButton.Visibility = Visibility.Collapsed;
        }

        private void PopupRemoveSharedItineraryButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveSharedItinerary.Visibility = Visibility.Collapsed;
            ItineraryPage.DisableSharedTab();
            this.NavigationService.Navigate(ItineraryPage);

            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            ImportOKButton.Visibility = Visibility.Collapsed;
            KeyboardButton.Visibility = Visibility.Hidden;
            CodeImportStack.Visibility = Visibility.Collapsed;

            PopupCancelSharingButton.Visibility = Visibility.Collapsed;
            PopupNoButton.Visibility = Visibility.Collapsed;
            PopupRemoveSharedItineraryButton.Visibility = Visibility.Collapsed;
        }

        private void PopupNoButton_Click(object sender, RoutedEventArgs e)
        {
            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            ImportOKButton.Visibility = Visibility.Collapsed;
            KeyboardButton.Visibility = Visibility.Hidden;
            CodeImportStack.Visibility = Visibility.Collapsed;

            PopupCancelSharingButton.Visibility = Visibility.Collapsed;
            PopupNoButton.Visibility = Visibility.Collapsed;
            PopupRemoveSharedItineraryButton.Visibility = Visibility.Collapsed;
        }

        private void StopExportingItinerary_Click(object sender, RoutedEventArgs e)
        {
            ImportPopUpLabel.Content = new TextBlock
            {
                Text = "Are you sure you want to stop sharing your itinerary? This will remove your itinerary from the shared tab of anyone that can see your shared itinerary.",
                TextWrapping = TextWrapping.Wrap
            };
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            CodeImportStack.Visibility = Visibility.Visible;
            PopupCancelSharingButton.Visibility = Visibility.Visible;
            PopupNoButton.Visibility = Visibility.Visible;
        }

        private void RemoveSharedItinerary_Click(object sender, RoutedEventArgs e)
        {
            ImportPopUpLabel.Content = new TextBlock
            {
                Text = "Are you sure you want to remove the shared itinerary? You will not be able to see the previously shared itinerary without another code.",
                TextWrapping = TextWrapping.Wrap
            };
            BlurredPopUpBackground.Visibility = Visibility.Visible;
            CodeImportStack.Visibility = Visibility.Visible;
            PopupRemoveSharedItineraryButton.Visibility = Visibility.Visible;
            PopupNoButton.Visibility = Visibility.Visible;
        }

        private void BlurredPopUpBackground_Click(object sender, RoutedEventArgs e)
        {
            BlurredPopUpBackground.Visibility = Visibility.Hidden;
            ImportOKButton.Visibility = Visibility.Collapsed;
            KeyboardButton.Visibility = Visibility.Hidden;
            CodeImportStack.Visibility = Visibility.Collapsed;

            PopupCancelSharingButton.Visibility = Visibility.Collapsed;
            PopupNoButton.Visibility = Visibility.Collapsed;
            PopupRemoveSharedItineraryButton.Visibility = Visibility.Collapsed;
        }

        public void InvertedToggle(object sender, MouseButtonEventArgs e)
        {
            ItineraryPage._page1.ToggleInversion();
        }
    }
}
