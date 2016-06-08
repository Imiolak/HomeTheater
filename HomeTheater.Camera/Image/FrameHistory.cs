using System;
using System.Collections.Generic;
using System.Drawing;

namespace HomeTheater.Camera.Image
{
    public class FrameHistory
    {
        private readonly int _capacity;
        private readonly LinkedList<Tuple<Gesture, Point>> _frameHistory; 

        public FrameHistory(int capacity)
        {
            _capacity = capacity;
            _frameHistory = new LinkedList<Tuple<Gesture, Point>>();
        }

        public void Add(Tuple<Gesture, Point> newFrame)
        {
            if (_frameHistory.Count >= _capacity)
                _frameHistory.RemoveFirst();

            _frameHistory.AddLast(newFrame);
        }
    }
}
