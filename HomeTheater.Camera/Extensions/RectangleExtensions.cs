using System;
using System.Drawing;
using Emgu.CV.CvEnum;

namespace HomeTheater.Camera.Extensions
{
    public static class RectangleExtensions
    {
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(
                Math.Abs(rectangle.Left - rectangle.Right),
                Math.Abs(rectangle.Top - rectangle.Bottom));
        }
    }
}
