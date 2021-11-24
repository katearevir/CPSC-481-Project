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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private trvlApp.Page1 _page1;

        public Page2(trvlApp.Page1 page1)
        {
            InitializeComponent();
            _page1 = page1;
        }

        public void NavigatePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_page1);
        }


    }
}
