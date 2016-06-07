using System.Windows.Controls;

namespace HomeTheater.Common.Input
{
    public interface IInputMethod
    {
        bool Available { get; }

        bool Active { get; }

        string Description { get; }

        UserControl InputPanel { get; }

        UserControl DebugPanel { get; }

        void Start();

        void Stop();
    }
}
