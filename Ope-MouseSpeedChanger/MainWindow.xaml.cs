using System.Collections.Generic;
using System.Diagnostics;
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

namespace Ope_MouseSpeedChanger
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SliderThingy.Value = User32.GetMouseSpeed();
            UpdateSliderLabel();
            UpdateLabel((int)SliderThingy.Value);
        }

        private void UpdateSliderLabel()
        {
            SliderLabel.Content = "Slider value: " + SliderThingy.Value;
        }

        private void UpdateLabel(int value)
        {
            LabelThingy.Content = "Current mouse speed : " + value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateLabel(User32.SetMouseSpeed((uint)SliderThingy.Value));
        }

        private void PresetButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateLabel(User32.SetMouseSpeed(uint.Parse(((Button)sender).Tag.ToString())));
        }

        private void SliderThingy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateSliderLabel();
        }
    }
}
