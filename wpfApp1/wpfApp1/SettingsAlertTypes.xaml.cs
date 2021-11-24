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
    /// Interaction logic for SettingsAlertTypes.xaml
    /// </summary>
    public partial class SettingsAlertTypes : Window
    {
        public SettingsAlertTypes()
        {
            InitializeComponent();
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            wpfApp1.MainWindow objSettingsWindow = new wpfApp1.MainWindow();
            this.Visibility = Visibility.Hidden; // hiding current window 
            objSettingsWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
