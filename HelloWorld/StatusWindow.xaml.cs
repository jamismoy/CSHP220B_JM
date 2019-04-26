﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        public StatusWindow()
        {
            InitializeComponent();
            uxProgressBar.Maximum = uxTextEditor.MaxLength; ; // Set the maximum
        }

        private void uxTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);
            int col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);

            uxStatus.Text = "Line " + (row + 1) + ", Char " + (col + 1);

            uxProgressBar.Value = uxTextEditor.Text.Length;

            int percent = uxTextEditor.Text.Length * 100 / uxTextEditor.MaxLength;

            uxPercentComplete.Text = string.Format("{0}%", percent);
        }
    }
}
