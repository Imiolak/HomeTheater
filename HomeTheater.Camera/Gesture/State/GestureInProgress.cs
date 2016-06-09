using System;
using HomeTheater.Common.Driver;
using HomeTheater.Common.Driver.Audio;

namespace HomeTheater.Camera.Gesture.State
{
    public class GestureInProgress : IState
    {
        private const double NeededVerticalMove = 0.2D;
        private const double NeedeHorizontalMove = 0.15;
        private readonly double _initialX;
        private readonly double _initialY;
        private readonly IAudioDriver _audioDriver;

        public GestureInProgress(double initialX, double initialY)
        {
            _initialX = initialX;
            _initialY = initialY;
            _audioDriver = DriverProvider.GetAudioDriver();

            Console.WriteLine("Transition to GESTURE IN PROGRESS");
        }

        public IState Transition(Gesture gesture, double x, double y)
        {
            switch (gesture)
            {
                case Gesture.None:
                    return new Idle();
                case Gesture.OpenPalm:
                    GestureEnded(x, y);
                    return new Idle();
                case Gesture.ClosedPalm:
                    return this;
                default:
                    return new Idle();
            }
        }

        private void GestureEnded(double x, double y)
        {
            Console.WriteLine("Gesture ended");
            if (HandDidntMove(x, y))
            {
                _audioDriver.PlayPause();
            }
            else if (HandMovedVertivally(y))
            {
                if (HandMovedUp(y))
                {
                    _audioDriver.VolumeUp();
                }
                else
                {
                    _audioDriver.VolumeDown();
                }
            }
            else if (HandMovedHorizontally(x))
            {
                if (HandMovedRight(x))
                {
                    _audioDriver.NextTrack();
                }
                else
                {
                    _audioDriver.PreviousTrack();
                }
            }
        }
        
        private bool HandDidntMove(double x, double y)
        {
            return !HandMovedHorizontally(x)
                   && !HandMovedVertivally(y);
        }
        
        private bool HandMovedVertivally(double y)
        {
            return Math.Abs(_initialY - y) > NeededVerticalMove;
        }

        private bool HandMovedHorizontally(double x)
        {
            return Math.Abs(_initialX - x) > NeedeHorizontalMove;
        }

        private bool HandMovedUp(double y)
        {
            return _initialY - y > 0;
        }

        private bool HandMovedRight(double x)
        {
            return _initialX - x > 0;
        }
    }
}
