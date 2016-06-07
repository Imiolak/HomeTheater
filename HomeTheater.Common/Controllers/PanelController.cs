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
            _inputPanel.Children.Add(inputPanel);
        }

        public void SetDebugPanel(UserControl debugPanel)
        {
            _debugPanel.Children.Add(debugPanel);
        }

        public void RemovePanels(UserControl inputPanel, UserControl debugPanel)
        {
            _inputPanel.Children.Remove(inputPanel);
            _debugPanel.Children.Remove(debugPanel);
        }
    }
}
