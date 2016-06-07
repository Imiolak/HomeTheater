using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HomeTheater.Common.Controllers;
using HomeTheater.Common.Input;

namespace HomeTheater.GUI.Controls
{
    /// <summary>
    /// Interaction logic for InputMethodButton.xaml
    /// </summary>
    public partial class InputMethodButton : UserControl
    {
        private readonly IInputMethod _inputMethod;
        private readonly PanelController _panelController;

        public InputMethodButton(IInputMethod inputMethod, PanelController panelController)
        {
            _inputMethod = inputMethod;
            _panelController = panelController;

            Text = _inputMethod.Description;
            IsEnabled = _inputMethod.Available;

            InitializeComponent();
        }

        public string Text { get; set; }

        public bool Selected => _inputMethod.Active;

        private void Select()
        {
            StatusIndicator.Fill = new SolidColorBrush(Colors.Green);

            _inputMethod.Start();
            _panelController.SetInputPanel(_inputMethod.InputPanel);
            _panelController.SetDebugPanel(_inputMethod.DebugPanel);
        }

        private void Deselect()
        {
            StatusIndicator.Fill = new SolidColorBrush(Colors.Red);

            _inputMethod.Stop();
            _panelController.RemovePanels(_inputMethod.InputPanel, _inputMethod.DebugPanel);
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
