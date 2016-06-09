using System.Collections.Generic;
using HomeTheater.Camera.Gesture.State;

namespace HomeTheater.Camera.Gesture
{
    public class GestureParser
    {
        private readonly IDictionary<Gesture, double> _neededPercentages;
        private readonly GestureHistory _gestureHistory; 
        private IState _currentState;

        public GestureParser()
        {
            _gestureHistory = new GestureHistory(15);
            _currentState = new Idle();
            _neededPercentages = new Dictionary<Gesture, double>
            {
                { Gesture.None, 0.7 },
                { Gesture.OpenPalm, 0.4 },
                { Gesture.ClosedPalm, 0.45 }
            };
        }

        public void ParseNext(Gesture gesture, double x = 0, double y = 0)
        {
            _gestureHistory.AddNew(gesture);
            if (_gestureHistory.PercentageOf(gesture) >= _neededPercentages[gesture])
            {
                _currentState = _currentState.Transition(gesture, x, y);
            }
        }
    }

    public enum Gesture
    {
        None,
        OpenPalm,
        ClosedPalm
    }
}
