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
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        Thickness LeftSide = new Thickness(-50, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0, 50, 0);
        SolidColorBrush ButtonOff = new SolidColorBrush(Color.FromRgb(160,160,160));
        SolidColorBrush ButtonOn = new SolidColorBrush(Color.FromRgb(130,190,125));
        private bool Toggled = false; 

        public ToggleButton()
        {
            InitializeComponent();
            ToggleButtonBackground.Fill = ButtonOff;
            Toggled = false;
            ToggleButtonCircle.Margin = LeftSide;
        }

        public bool Toggled1
        {
            get => Toggled;
            set => Toggled = value;
        }
        private void toggleCircleButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Toggled)
            {
                ToggleButtonBackground.Fill = ButtonOn;
                Toggled = true;

                ToggleButtonCircle.Margin = RightSide;

            }
            else
            {
                ToggleButtonBackground.Fill = ButtonOff;
                Toggled = false;
                ToggleButtonCircle.Margin = LeftSide;
            }
        }

        private void toggleBackgroundDown(object sender, MouseButtonEventArgs e)
        {
            if (!Toggled)
            {
                ToggleButtonBackground.Fill = ButtonOn;
                Toggled = true;
                ToggleButtonCircle.Margin = RightSide;

            }
            else
            {

                ToggleButtonBackground.Fill = ButtonOff;
                Toggled = false;
                ToggleButtonCircle.Margin = LeftSide;

            }

        }

    }
}
