using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HomeTheater.Common.Input;

namespace HomeTheater.GUI.Controls
{
    /// <summary>
    /// Interaction logic for InputMethodButton.xaml
    /// </summary>
    public partial class InputMethodButton : UserControl
    {
        private readonly IInputMethod _inputMethod;

        public InputMethodButton(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
            Text = _inputMethod.Description;
            IsEnabled = _inputMethod.Available;

            InitializeComponent();
        }

        public string Text { get; set; }

        public bool Selected
        {
            get { return _inputMethod.Active; }
        } 

        private void Select()
        {
            StatusIndicator.Fill = new SolidColorBrush(Colors.Green);
            _inputMethod.Start();
        }

        private void Deselect()
        {
            StatusIndicator.Fill = new SolidColorBrush(Colors.Red);
            _inputMethod.Stop();
        }

        private void Toggle(object sender, MouseButtonEventArgs e)
        {
            if (Selected)
                Deselect();
            else
                Select();
        }
    }
}
