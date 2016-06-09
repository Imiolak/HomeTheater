using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using HomeTheater.Camera.Extensions;
using HomeTheater.Camera.Gesture;

namespace HomeTheater.Camera.Image
{
    public class FrameInterpreter
    {
        private const string HaarFilesLocation = @"..\..\..\..\HomeTheater.Camera\haarcascades\";
        private const string OpenPalmHaarFilePath = HaarFilesLocation + "haarcascade_palm.xml";
        private const string ClosedPalmHaarFilePath = HaarFilesLocation + "haarcascade_closed_palm.xml";

        private readonly GestureParser _parser;

        public FrameInterpreter()
        {
            _parser = new GestureParser();
        }

        public Mat Process(Mat frame)
        {
            var imageFrame = frame.ToImage<Bgr, byte>().Flip(FlipType.Horizontal);
            var grayFrame = imageFrame.Convert<Gray, byte>();

            var openPalmHaar = new CascadeClassifier(OpenPalmHaarFilePath);
            var openPalms = openPalmHaar.DetectMultiScale(grayFrame, 1.4, 4);
            var closedPalmHaar = new CascadeClassifier(ClosedPalmHaarFilePath);
            var closedPalms = closedPalmHaar.DetectMultiScale(grayFrame, 1.4, 4);

            var anyOpenPalm = openPalms.Any();
            var anyClosedPalm = closedPalms.Any();

            if ((anyOpenPalm && anyClosedPalm) 
                || (!anyOpenPalm && !anyClosedPalm))
            {
                _parser.ParseNext(Gesture.Gesture.None);
            }
            else if (anyOpenPalm)
            {
                _parser.ParseNext(Gesture.Gesture.OpenPalm, 
                    openPalms[0].Center().X / (double)imageFrame.Width,
                    openPalms[0].Center().Y / (double)imageFrame.Height);
                imageFrame.Draw(openPalms[0], new Bgr(Color.Green));
            }
            else 
            {
                _parser.ParseNext(Gesture.Gesture.ClosedPalm,
                    closedPalms[0].Center().X / (double)imageFrame.Width,
                    closedPalms[0].Center().Y / (double)imageFrame.Height);
                imageFrame.Draw(closedPalms[0], new Bgr(Color.Blue));
            }

            return imageFrame.Mat;
        }
    }
}
