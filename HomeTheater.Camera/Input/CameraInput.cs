using HomeTheater.Common.Input;

namespace HomeTheater.Camera.Input
{
    public class CameraInput : IInputMethod
    {
        private const string _description = "Camera";

        public bool Available
        {
            get { return false; }
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
