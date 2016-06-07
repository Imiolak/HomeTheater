using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HomeTheater.GUI.Controls
{
    /// <summary>
    /// Interaction logic for OnOffButton.xaml
    /// </summary>
    public partial class OnOffButton : UserControl
    {
        public OnOffButton()
        {
            InitializeComponent();

            StatusText.Text = "Off";
            IsOn = false;
        }

        public bool IsOn { get; private set; }

        private void Select()
        {
            StatusIndicator.Fill = new SolidColorBrush(Colors.Green);
            IsOn = true;
            StatusText.Text = "On";
        }

        private void Deselect()
        {
            StatusIndicator.Fill = new SolidColorBrush(Colors.Red);
            IsOn = false;
            StatusText.Text = "Off";
        }

        private void Toggle(object sender, MouseButtonEventArgs e)
        {
            if (IsOn)
                Deselect();
            else
                Select();
        }
    }
}
