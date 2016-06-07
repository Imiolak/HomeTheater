using System.Windows;
using System.Windows.Controls;
using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;

namespace HomeTheater.GUI.Panels
{
    /// <summary>
    /// Interaction logic for GUIInputPanel.xaml
    /// </summary>
    public partial class GUIInputPanel : UserControl
    {
        private readonly IAudioDriver _audioDriver;
        private readonly IVideoDriver _videoDriver;

        public GUIInputPanel()
        {
            InitializeComponent();
        }

        public GUIInputPanel(IAudioDriver audioDriver, IVideoDriver videoDriver) : this()
        {
            _audioDriver = audioDriver;
            _videoDriver = videoDriver;
        }
        
        private void PreviousTrackButton_Click(object sender, RoutedEventArgs e)
        {
            _audioDriver.PreviousTrack();
        }

        private void StopButon_Click(object sender, RoutedEventArgs e)
        {
            _audioDriver.Stop();
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            _audioDriver.PlayPause();
        }

        private void NextTrackButton_Click(object sender, RoutedEventArgs e)
        {
            _audioDriver.NextTrack();
        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            _audioDriver.Mute();
        }

        private void VolumeDownButtonClick(object sender, RoutedEventArgs e)
        {
            _audioDriver.VolumeDown();
        }

        private void VolumeUpButton_Click(object sender, RoutedEventArgs e)
        {
            _audioDriver.VolumeUp();
        }
    }
}
