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

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public bool PlayerTurn { get; set; }

        public int Counter { get; set; }

        public Button[,] array;
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        public void NewGame()
        {
            PlayerTurn = false;
            Counter = 0;

            array = new Button[,] { { Button_0_0, Button_0_1, Button_0_2 }, { Button_1_0, Button_1_1, Button_1_2 }, { Button_2_0, Button_2_1, Button_2_2 } };

            for(int i = 0; i<=2; i++)
            {
                for(int j = 0; j <= 2; j++)
                {
                    array[i, j].Content = string.Empty;
                    array[i, j].Background = Brushes.White;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if(button.Content.ToString() == string.Empty)
            {
                PlayerTurn ^= true;

                button.Content = PlayerTurn ? "O" : "X";

                Counter++;
            }
            if (Counter > 9)
            {
                NewGame();
                return;
            }
            if (IsGameWon())
            {
                Counter = 10;
                return;
            }
            if (IsFull())
            {
                NewGame();
            }
        }

        private bool IsGameWon()
        {
            array = new Button[,] { { Button_0_0, Button_0_1, Button_0_2 }, { Button_1_0, Button_1_1, Button_1_2 }, { Button_2_0, Button_2_1, Button_2_2 } };
            for (int i = 0; i <= 2; i++)
            {
                if(array[i, 0].Content.ToString() != string.Empty && array[i, 0].Content == array[i, 1].Content && array[i, 0].Content == array[i, 2].Content)
                {
                    for(int j = 0; j<=2; j++)
                    {
                        array[i, j].Background = Brushes.LightGreen;
                    }
                    return true;
                }
                if(array[0, i].Content.ToString() != string.Empty && array[0, i].Content == array[1, i].Content && array[0, i].Content == array[2, i].Content)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        array[j, i].Background = Brushes.LightGreen;
                    }
                    return true;
                }
                if(array[0, 0].Content.ToString() != string.Empty && array[0, 0].Content == array[1, 1].Content && array[0, 0].Content == array[2, 2].Content)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        array[j, j].Background = Brushes.LightGreen;
                    }
                    return true;
                }
                if(array[0, 2].Content.ToString() != string.Empty && array[0, 2].Content == array[1, 1].Content && array[0, 2].Content == array[2, 0].Content)
                {
                    array[0, 2].Background = Brushes.LightGreen;
                    array[1, 1].Background = Brushes.LightGreen;
                    array[2, 0].Background = Brushes.LightGreen;
                    return true;
                }
            }
            return false;
        }

        private bool IsFull()
        {
            int full = 0;
            for(int i=0; i<=2; i++)
            {
                for(int j=0; j<=2; j++)
                {
                    if (array[i, j].Content.ToString() != string.Empty)
                    {
                        full++;
                    }
                }
            }
            if(full == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}