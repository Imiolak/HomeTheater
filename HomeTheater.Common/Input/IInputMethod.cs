namespace HomeTheater.Common.Input
{
    public interface IInputMethod
    {
        bool Available { get; }

        bool Active { get; }

        string Description { get; }

        void Start();

        void Stop();
    }
}
