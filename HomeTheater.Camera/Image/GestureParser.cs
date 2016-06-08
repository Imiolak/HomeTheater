using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HomeTheater.Camera.Image
{
    public class GestureParser
    {
        private LinkedList<Tuple<Gesture, Point>> frameHistory; 
        private State currentState;

        public void ParseNext(Gesture gesture, Point center)
        {
            Console.WriteLine($"{gesture} {DateTime.Now.ToLongTimeString()}");
        }
    }

    public enum Gesture
    {
        None,
        OpenPalm,
        ClosedPalm
    }

    public enum State
    {
        Idle
    }
}
