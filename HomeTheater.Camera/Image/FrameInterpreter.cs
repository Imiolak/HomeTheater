using Emgu.CV;
using Emgu.CV.Structure;

namespace HomeTheater.Camera.Image
{
    public class FrameInterpreter
    {
        private const string HaarFilesLocation = @"..\..\..\..\HomeTheater.Camera\haarcascades\";
        private const string PalmHaarFilePath = HaarFilesLocation + "haarcascade_palm.xml";
        private const string ClosedPalmHaarFilePath = HaarFilesLocation + "haarcascade_closed_palm.xml";
        
        public Mat Process(Mat frame)
        {
            var imageFrame = frame.ToImage<Bgr, byte>();
            var grayFrame = imageFrame.Convert<Gray, byte>();

            var palmHaar = new CascadeClassifier(PalmHaarFilePath);
            var palms = palmHaar.DetectMultiScale(grayFrame, 1.4, 4);
            var closedPalmHaar = new CascadeClassifier(ClosedPalmHaarFilePath);
            var closedPalms = closedPalmHaar.DetectMultiScale(grayFrame, 1.4, 4);

            foreach (var palm in palms)
            {
                imageFrame.Draw(palm, new Bgr(0, double.MaxValue, 0), 0);
            }
            
            foreach (var closedPalm in closedPalms)
            {
                imageFrame.Draw(closedPalm, new Bgr(0, double.MaxValue, 0), 0);
            }

            return imageFrame.Mat;
        }
    }
}
