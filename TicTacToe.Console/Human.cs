using System.Linq.Expressions;
using TicTacToe.Core;

namespace TicTacToe.Console
{
    internal class Human : Player
    {
        public Human(string playingChar, string name = "undefined")
            : base(playingChar, name)
        {
        }
        public override void MakeMove(Action? action = null)
        {
            
            SafeMove(() =>
            {
                Print(Matrix.MainMatrix);
                Console.WriteLine($"{playingChar} player's move");
                System.Console.WriteLine("enter the cell address for your char");

                FirstIndex = Convert.ToInt32(System.Console.ReadLine());
                SecondIndex = Convert.ToInt32(System.Console.ReadLine());
            });
        }

        public void Print(char[][] MainMatrix)
        {
            char[,] MatrixUI = {
                {' ', '|', '0', '1', '2'},
                {'—', '+', '—', '—', '—'},
                {'0', '|', '#', '#', '#'},
                {'1', '|', '#', '#', '#'},
                {'2', '|', '#', '#', '#'}
            };

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    MatrixUI[row + 2, column + 2] = MainMatrix[row][column];
                }
            }

            System.Console.Clear();
            char Helper;
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (row == 1) Helper = '-';
                    else Helper = ' ';
                    System.Console.Write($"{MatrixUI[row, column]}" + $"{Helper}");
                }
                System.Console.WriteLine();
            }
        }
    }
}
