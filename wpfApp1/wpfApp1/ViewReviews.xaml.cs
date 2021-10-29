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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ViewReviews : Window
    {
        public ViewReviews()
        {
            InitializeComponent();
        }

        public void OpenSettingsWindow(object sender, RoutedEventArgs e)
        {
            trvlApp.SettingsWindow objSettingsWindow = new trvlApp.SettingsWindow();
            this.Visibility = Visibility.Hidden; // hiding current window 
            objSettingsWindow.Show();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Frame_Navigated_1(object sender, NavigationEventArgs e)
        {

        }

    }
}
