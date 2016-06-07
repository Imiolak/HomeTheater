using System;
using Emgu.CV;
using Emgu.CV.Structure;
using HomeTheater.Camera.Panels;

namespace HomeTheater.Camera.Image
{
    public class CameraCapture
    {
        private readonly CameraDebugPanel _debugPanel;
        private readonly Capture _capture;
        private readonly FrameInterpreter _frameInterpreter;
        private bool _capturing; 

        public CameraCapture(CameraDebugPanel debugPanel)
        {
            _debugPanel = debugPanel;

            CvInvoke.UseOpenCL = false;
            _capture = new Capture();
            _capture.ImageGrabbed += ProcessFrame;

            _frameInterpreter = new FrameInterpreter();
        }

        public void Start()
        {
            if (_capturing)
                return;

            _capture.Start();
            _capturing = true;
        }

        public void Stop()
        {
            if (!_capturing)
                return;

            _capture.Stop();
            _capturing = false;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            var frame = new Mat();
            _capture.Retrieve(frame);
            
            var processedFrame = _frameInterpreter.Process(frame);

            _debugPanel.SetImage(processedFrame);
        }
    }
}
