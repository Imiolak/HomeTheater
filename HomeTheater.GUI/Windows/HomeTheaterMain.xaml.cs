using System.Windows;
using HomeTheater.Camera.Input;
using HomeTheater.Common.Controllers;
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
            var panelController = new PanelController(InputPanel, DebugPanel);

            Configuration.Children.Add(new OnOffButton());

            InputMethodsButton.Children.Add(new InputMethodButtonGroup(
                new InputMethodButton(new GuiInput(audioDriver, videoDriver), panelController),
                new InputMethodButton(new CameraInput(audioDriver, videoDriver), panelController),
                new InputMethodButton(new KinectInput(audioDriver, videoDriver), panelController)
            ));
        }
    }
}
