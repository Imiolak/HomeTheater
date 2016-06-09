namespace HomeTheater.Camera.Gesture.State
{
    public interface IState
    {
        IState Transition(Gesture gesture, double x = 0, double y = 0);
    }
}
