﻿using System.Windows.Controls;

namespace HomeTheater.GUI.Controls
{
    /// <summary>
    /// Interaction logic for InputMethodButtonGroup.xaml
    /// </summary>
    public partial class InputMethodButtonGroup : UserControl
    {
        public InputMethodButtonGroup(params InputMethodButton[] buttons)
        {
            
            InitializeComponent();

            foreach (var button in buttons)
            {
                ButtonContainer.Children.Add(button);
            }
        }
    }
}
