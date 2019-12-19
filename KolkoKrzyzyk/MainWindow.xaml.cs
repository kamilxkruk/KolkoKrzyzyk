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

namespace KolkoKrzyzyk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum ButtonState
        {
            Circle,
            Cross,
            Empty
        }

        private ButtonState[] buttonStates;
        private bool gameEnd = false;
        private bool ifPlayerOne = true;

        public MainWindow()
        {
            InitializeComponent();
            buttonStates = new ButtonState[9];
            NewGame();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (gameEnd)
            {
                NewGame();
            }

            Button currentButton = (Button)sender;

            var currentRow = Grid.GetRow(currentButton);
            var currentColumn = Grid.GetColumn(currentButton);

            var index = currentColumn + currentRow * 3;

            MessageBox.Show(index.ToString());

            if(currentButton.Content != string.Empty)
            {
                return;
            }

            if (ifPlayerOne)
            {
                currentButton.Content = "X";
                buttonStates[index] = ButtonState.Cross;
            }
            else
            {
                currentButton.Content = "O";
                buttonStates[index] = ButtonState.Circle;
            }

            ifPlayerOne = !ifPlayerOne;
        }

        private void NewGame()
        {
            Container.Children.Cast<Button>().ToList().ForEach(button => button.Content = string.Empty);

            for (int i = 0; i < 9; i++)
            {
                buttonStates[i] = ButtonState.Empty;
            }
        }
    }
}
