using System;
using System.Drawing;

namespace HomeTheater.Camera.Extensions
{
    public static class RectangleExtensions
    {
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(
                rectangle.Right - (Math.Abs(rectangle.Left - rectangle.Right) / 2),
                rectangle.Bottom - (Math.Abs(rectangle.Top - rectangle.Bottom) / 2));
        }
    }
}
