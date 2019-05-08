using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            uxSubmitButton.IsEnabled = IsPostalCode();
        }

        private bool IsPostalCode()
        {
            string text = uxTextBox.Text;
            if (uxTextBox.Text.Length > 0 && uxTextBox.Text != null)
            {
                Regex cString = new Regex(@"^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$",
                    RegexOptions.IgnoreCase);
                Regex aString = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$", RegexOptions.IgnoreCase);
                MatchCollection cMatches = cString.Matches(text);
                MatchCollection aMatches = aString.Matches(text);
                if (cMatches.Count > 0 || aMatches.Count > 0)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
