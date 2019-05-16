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

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int counter;

        int xUpDiagCount;
        int xDownDiagCount;
        int xColumnCount0;
        int xColumnCount1;
        int xColumnCount2;
        int xRowCount0;
        int xRowCount1;
        int xRowCount2;

        int oUpDiagCount;
        int oDownDiagCount;
        int oColumnCount0;
        int oColumnCount1;
        int oColumnCount2;
        int oRowCount0;
        int oRowCount1;
        int oRowCount2;

        public MainWindow()
        {
            InitializeComponent();
            reset();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            if (button.Content == null)
            {
                if (counter % 2 == 1)
                {
                    button.Content = "X";
                    if (isThreeInARow(button))
                    {
                        uxTurn.Text = "X is a winner";
                    }
                    else
                    {
                        uxTurn.Text = "O's turn";
                    }
                }
                else
                {
                    button.Content = "O";
                    if (isThreeInARow(button))
                    {
                        uxTurn.Text = "O is a winner";
                    }
                    else
                    {
                        uxTurn.Text = "X's turn";
                    }
                }
                counter++;
            }
            
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            reset();
            List<Button> buttons = castButtonsToList();
            foreach (Button button in buttons)
            {
                button.Content = null;
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private List<Button> castButtonsToList()
        {
            UIElementCollection element = uxGrid.Children;
            List<FrameworkElement> elements = element.Cast<FrameworkElement>().ToList();
            List<Button> buttons = elements.OfType<Button>().ToList();
            return buttons;
        }

        //[00 01 02
        // 10 11 12
        // 20 21 22]

        private bool isThreeInARow(Button button)
        {
            // convert tags to ints
            char[] charArray = button.Tag.ToString().ToCharArray();
            int row = (int)Char.GetNumericValue(charArray[0]);
            int column = (int)Char.GetNumericValue(charArray[2]);

            if ((string)button.Content == "X")
            {
                if (row + column == 2)
                {
                    xUpDiagCount++;
                }
                if (row == column)
                {
                    xDownDiagCount++;
                }
                if (column == 0)
                {
                    xColumnCount0++;
                }
                if (column == 1)
                {
                    xColumnCount1++;
                }
                if (column == 2)
                {
                    xColumnCount2++;
                }
                if (row == 0)
                {
                    xRowCount0++;
                }
                if (row == 1)
                {
                    xRowCount1++;
                }
                if (row == 2)
                {
                    xRowCount2++;
                }
            }

            if ((string)button.Content == "O")
            {
                if (row + column == 2)
                {
                    oUpDiagCount++;
                }
                if (row == column)
                {
                    oDownDiagCount++;
                }
                if (column == 0)
                {
                    oColumnCount0++;
                }
                if (column == 1)
                {
                    oColumnCount1++;
                }
                if (column == 2)
                {
                    oColumnCount2++;
                }
                if (row == 0)
                {
                    oRowCount0++;
                }
                if (row == 1)
                {
                    oRowCount1++;
                }
                if (row == 2)
                {
                    oRowCount2++;
                }

            }

            if (xUpDiagCount == 3 || xDownDiagCount == 3 || oUpDiagCount == 3 || oDownDiagCount == 3
                || xColumnCount0 == 3 || xColumnCount1 == 3 || xColumnCount2 == 3
                || xRowCount0 == 3 || xRowCount1 == 3 || xRowCount2 == 3
                || oColumnCount0 == 3 || oColumnCount1 == 3 || oColumnCount2 == 3
                || oRowCount0 == 3 || oRowCount1 == 3 || oRowCount2 == 3)
            {
                uxGrid.IsEnabled = false;
                return true;
            }
            return false;
        }

        private void reset()
        {
            counter = 1;
            xUpDiagCount = 0;
            xDownDiagCount = 0;
            oUpDiagCount = 0;
            oDownDiagCount = 0;
            xColumnCount0 = 0;
            xColumnCount1 = 0;
            xColumnCount2 = 0;
            xRowCount0 = 0;
            xRowCount1 = 0;
            xRowCount2 = 0;
            oColumnCount0 = 0;
            oColumnCount1 = 0;
            oColumnCount2 = 0;
            oRowCount0 = 0;
            oRowCount1 = 0;
            oRowCount2 = 0;
            uxGrid.IsEnabled = true;
            uxTurn.Text = "";
        }
    }
}
