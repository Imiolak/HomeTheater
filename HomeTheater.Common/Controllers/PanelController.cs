using System.Windows.Controls;

namespace HomeTheater.Common.Controllers
{
    public class PanelController
    {
        private readonly StackPanel _inputPanel;
        private readonly StackPanel _debugPanel;

        public PanelController(StackPanel inputPanel, StackPanel debugPanel)
        {
            _inputPanel = inputPanel;
            _debugPanel = debugPanel;
        }

        public void SetInputPanel(UserControl inputPanel)
        {
            _inputPanel.Children.Clear();
            _inputPanel.Children.Add(inputPanel);
        }

        public void SetDebugPanel(UserControl debugPanel)
        {
            _debugPanel.Children.Clear();
            _debugPanel.Children.Add(debugPanel);
        }

        public void ClearPanels()
        {
            _inputPanel.Children.Clear();
            _debugPanel.Children.Clear();
        }
    }
}
