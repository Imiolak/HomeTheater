using System.Windows.Controls;
using Emgu.CV;
using Emgu.CV.UI;

namespace HomeTheater.Camera.Panels
{
    /// <summary>
    /// Interaction logic for CameraDebugPanel.xaml
    /// </summary>
    public partial class CameraDebugPanel : UserControl
    {
        public CameraDebugPanel()
        {
            InitializeComponent();
        }

        public void SetImage(Mat image)
        {
            ImgBox.Image = image;
        }
    }
}
