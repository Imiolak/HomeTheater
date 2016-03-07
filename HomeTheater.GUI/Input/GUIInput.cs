using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;

namespace HomeTheater.GUI.Input
{
    public class GuiInput : InputBase, IInputMethod
    {
        public GuiInput(IAudioDriver audioDriver, IVideoDriver videoDriver) : base(audioDriver, videoDriver) { }

        public bool Available => true;

        public bool Active { get; private set; }

        public string Description => "GUI";

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
