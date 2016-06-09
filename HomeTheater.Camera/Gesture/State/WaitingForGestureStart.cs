using System;

namespace HomeTheater.Camera.Gesture.State
{
    public class WaitingForGestureStart : IState
    {
        public WaitingForGestureStart()
        {
            Console.WriteLine("Transition to WAITING FOR GESTURE START");
        }

        public IState Transition(Gesture gesture, double x = 0, double y = 0)
        {
            switch (gesture)
            {
                case Gesture.None:
                    return new Idle();
                case Gesture.OpenPalm:
                    return this;
                case Gesture.ClosedPalm:
                    return new GestureInProgress(x, y);
                default:
                    return new Idle();
            }
        }
    }
}
