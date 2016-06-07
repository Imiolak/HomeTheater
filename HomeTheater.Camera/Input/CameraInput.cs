using System.Windows.Controls;
using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;
using HomeTheater.Common.Panels;

namespace HomeTheater.Camera.Input
{
    public class CameraInput : InputBase, IInputMethod
    {
        public CameraInput(IAudioDriver audioDriver, IVideoDriver videoDriver)
            : base(audioDriver, videoDriver)
        {
        }

        public bool Available => false;

        public bool Active { get; private set; }

        public string Description => "Camera";

        public UserControl InputPanel => new EmptyUserControl();

        public UserControl DebugPanel => new EmptyUserControl();

        public void Start()
        {
            Active = true;
        }

        public void Stop()
        {
            Active = false;
        }

        
    }
}
