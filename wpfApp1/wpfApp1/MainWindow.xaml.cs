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

namespace wpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OpenSettingsWindow(object sender, RoutedEventArgs e)
        {
            trvlApp.SettingsWindow objSettingsWindow = new trvlApp.SettingsWindow();
            this.Visibility = Visibility.Hidden; // hiding current window 
            objSettingsWindow.Show();
        }

   
    }
}
