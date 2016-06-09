using System.Collections.Generic;
using System.Linq;

namespace HomeTheater.Camera.Gesture
{
    public class GestureHistory
    {
        private readonly int _capacity;
        private readonly LinkedList<Gesture> _gestureHistory;

        public GestureHistory(int capacity)
        {
            _capacity = capacity;
            _gestureHistory = new LinkedList<Gesture>();
        }

        public void AddNew(Gesture gesture)
        {
            if (_gestureHistory.Count >= _capacity)
                _gestureHistory.RemoveFirst();

            _gestureHistory.AddLast(gesture);
        }

        public double PercentageOf(Gesture gesture)
        {
            if (_gestureHistory.Count < _capacity)
                return 0;

            var percentage = _gestureHistory.Count(g => g == gesture) / (double) _gestureHistory.Count;
            return percentage;
        }
    }
}
