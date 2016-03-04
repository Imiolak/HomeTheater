using System.Windows;
using HomeTheater.Camera.Input;
using HomeTheaterGUI.Controls;
using HomeTheaterGUI.Input;

namespace HomeTheaterGUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeTheaterMain : Window
    {
        public HomeTheaterMain()
        {
            InitializeComponent();

            Buttons.Children.Add(new InputMethodButtonGroup(
                new InputMethodButton(new GuiInput()),
                new InputMethodButton(new CameraInput())
            ));
        }
    }
}
