using System.Windows.Controls;
using HomeTheater.Camera.Image;
using HomeTheater.Camera.Panels;
using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;
using HomeTheater.Common.Panels;

namespace HomeTheater.Camera.Input
{
    public class CameraInput : InputBase, IInputMethod
    {
        private readonly CameraCapture _capture;

        public CameraInput(IAudioDriver audioDriver, IVideoDriver videoDriver)
            : base(audioDriver, videoDriver)
        {
            InputPanel = new EmptyUserControl();
            DebugPanel = new CameraDebugPanel();

            _capture = new CameraCapture((CameraDebugPanel)DebugPanel);
        }

        public bool Available => true;

        public bool Active { get; private set; }

        public string Description => "Camera";

        public UserControl InputPanel { get; }

        public UserControl DebugPanel { get; }

        public void Start()
        {
            Active = true;
            _capture.Start();
        }

        public void Stop()
        {
            Active = false;
            _capture.Stop();
        }
    }
}
