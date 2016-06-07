using System.Windows.Controls;
using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;
using HomeTheater.Common.Panels;

namespace HomeTheater.Kinect.Input
{
    public class KinectInput : InputBase, IInputMethod
    {
        public KinectInput(IAudioDriver audioDriver, IVideoDriver videoDriver)
            : base(audioDriver, videoDriver)
        {
        }

        public bool Available => false;

        public bool Active { get; private set; }

        public string Description => "Kinect";

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
