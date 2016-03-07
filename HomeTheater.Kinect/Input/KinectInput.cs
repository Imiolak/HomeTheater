using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;

namespace HomeTheater.Kinect.Input
{
    public class KinectInput : InputBase, IInputMethod
    {
        public KinectInput(IAudioDriver audioDriver, IVideoDriver videoDriver) : base(audioDriver, videoDriver) { }

        public bool Available => false;

        public bool Active { get; private set; }

        public string Description => "Kinect";

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
