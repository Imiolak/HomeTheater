using System.Windows;
using HomeTheater.Camera.Input;
using HomeTheater.Common.Driver;
using HomeTheater.GUI.Controls;
using HomeTheater.GUI.Input;
using HomeTheater.Kinect.Input;

namespace HomeTheater.GUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeTheaterMain : Window
    {
        public HomeTheaterMain()
        {
            InitializeComponent();

            var audioDriver = DriverProvider.GetAudioDriver();
            var videoDriver = DriverProvider.GetVideoDriver();

            Buttons.Children.Add(new InputMethodButtonGroup(
                new InputMethodButton(new GuiInput(audioDriver, videoDriver)),
                new InputMethodButton(new CameraInput(audioDriver, videoDriver)),
                new InputMethodButton(new KinectInput(audioDriver, videoDriver))
            ));
        }
    }
}
