using System;

namespace HomeTheater.Camera.Gesture.State
{
    public class Idle : IState
    {
        public Idle()
        {
            Console.WriteLine("Transition to IDLE");
        }

        public IState Transition(Gesture gesture, double x = 0, double y = 0)
        {
            switch (gesture)
            {
                case Gesture.None:
                    return this;
                case Gesture.OpenPalm:
                    return new WaitingForGestureStart();
                case Gesture.ClosedPalm:
                    return this;
                default:
                    return this;
            }
        }
    }
}
