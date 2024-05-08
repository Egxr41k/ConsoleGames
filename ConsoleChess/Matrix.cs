namespace ConsoleChess;
internal class Matrix
{
    public static char[,] MainMatrix = new char[8, 8];

    public static void ToDefault()
    {
        char curChar;
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                if ((row + column) % 2 == 0) curChar = '#';
                else curChar = '.';

                if (row == 1) curChar = '♙';
                if (row == 0)
                {
                    if (column == 0 || column == 7) curChar = '♖';
                    if (column == 1 || column == 6) curChar = '♘';
                    if (column == 2 || column == 5) curChar = '♗';
                    if (column == 3) curChar = '♕';
                    if (column == 4) curChar = '♔';

                }
                if (row == 6) curChar = '♟';
                if (row == 7)
                {
                    if (column == 0 || column == 7) curChar = '♜';
                    if (column == 1 || column == 6) curChar = '♞';
                    if (column == 2 || column == 5) curChar = '♝';
                    if (column == 3) curChar = '♛';
                    if (column == 4) curChar = '♚';
                }
                MainMatrix[row, column] = curChar;

            }
        }
    }
    public static void Print()
    {
        char[,] MatrixUI = {
            {' ', '|', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '|', ' '},
            {'—', '+', '—', '—', '—', '—', '—', '—', '—', '—', '+', '—'},
            {'8', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '8'},
            {'7', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '7'},
            {'6', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '6'},
            {'5', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '5'},
            {'4', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '4'},
            {'3', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '3'},
            {'2', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '2'},
            {'1', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '1'},
            {'—', '+', '—', '—', '—', '—', '—', '—', '—', '—', '+', '—'},
            {' ', '|', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '|', ' '},
        };

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                MatrixUI[row + 2, column + 2] = MainMatrix[row, column];
            }
        }
        Console.Clear();
        char helper;
        for (int row = 0; row < 12; row++)
        {
            for (int column = 0; column < 12; column++)
            {
                if (row == 1 || row == 10) helper = '-';
                else helper = ' ';
                Console.Write($"{MatrixUI[row, column]}" + $"{helper}");
            }
            Console.WriteLine();
        }
    }
}

