using System.Windows.Controls;
using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;
using HomeTheater.Common.Panels;
using HomeTheater.GUI.Panels;

namespace HomeTheater.GUI.Input
{
    public class GuiInput : InputBase, IInputMethod
    {
        public GuiInput(IAudioDriver audioDriver, IVideoDriver videoDriver)
            : base(audioDriver, videoDriver)
        {
            InputPanel = new GUIInputPanel(AudioDriver, VideoDriver);
            DebugPanel = new EmptyUserControl();
        }

        public bool Available => true;

        public bool Active { get; private set; }

        public string Description => "GUI";

        public UserControl InputPanel { get; }

        public UserControl DebugPanel { get; }

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
