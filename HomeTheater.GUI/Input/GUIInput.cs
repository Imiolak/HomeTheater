using HomeTheater.Common.Input;

namespace HomeTheaterGUI.Input
{
    public class GuiInput : IInputMethod
    {
        private const string _description = "GUI";

        public bool Available
        {
            get { return true; }
        }

        public bool Active { get; private set; }

        public string Description
        {
            get { return _description; }
        }

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
