namespace ConsoleTicTacToe;
class Matrix
{
    public static char[,] MainMatrix = new char[3, 3];
    public static void MakeEmpty()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                MainMatrix[row, column] = '#';
            }
        }
    }
    public static void Print()
    {
        char[,] MatrixUI = {
            {' ', '|', '0', '1', '2'},
            {'—', '+', '—', '—', '—'},
            {'0', '|', '#', '#', '#'},
            {'1', '|', '#', '#', '#'},
            {'2', '|', '#', '#', '#'}
        };

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                MatrixUI[row + 2, column + 2] = MainMatrix[row, column];
            }
        }

        Console.Clear();
        char Helper;
        for (int row = 0; row < 5; row++)
        {
            for (int column = 0; column < 5; column++)
            {
                if (row == 1) Helper = '-';
                else Helper = ' ';
                Console.Write($"{MatrixUI[row, column]}" + $"{Helper}");
            }
            Console.WriteLine();
        }
    }
    public static bool CheckVictory()
    {
        bool Victory = false;
        if (//проверка по горизонтали
            MainMatrix[0, 0] == MainMatrix[0, 1] &&
            MainMatrix[0, 0] == MainMatrix[0, 2] &&
            MainMatrix[0, 0] != '#' ||
            MainMatrix[1, 0] == MainMatrix[1, 1] &&
            MainMatrix[1, 0] == MainMatrix[1, 2] &&
            MainMatrix[1, 0] != '#' ||
            MainMatrix[2, 0] == MainMatrix[2, 1] &&
            MainMatrix[2, 0] == MainMatrix[2, 2] &&
            MainMatrix[2, 0] != '#' ||
            //проверка по вертикали
            MainMatrix[0, 0] == MainMatrix[1, 0] &&
            MainMatrix[0, 0] == MainMatrix[2, 0] &&
            MainMatrix[0, 0] != '#' ||
            MainMatrix[0, 1] == MainMatrix[1, 1] &&
            MainMatrix[0, 1] == MainMatrix[2, 1] &&
            MainMatrix[0, 1] != '#' ||
            MainMatrix[0, 2] == MainMatrix[2, 1] &&
            MainMatrix[2, 0] == MainMatrix[2, 2] &&
            MainMatrix[0, 2] != '#' ||
            // проверка по диагонали
            MainMatrix[0, 0] == MainMatrix[1, 1] &&
            MainMatrix[0, 0] == MainMatrix[2, 2] &&
            MainMatrix[0, 0] != '#' ||
            MainMatrix[0, 2] == MainMatrix[1, 1] &&
            MainMatrix[0, 2] == MainMatrix[2, 0] &&
            MainMatrix[0, 2] != '#') Victory = true;

        return Victory;
    }
    public static bool CheckFull()
    {
        bool isFull = true;
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (MainMatrix[row, column] == '#')
                {
                    isFull = false;
                    break;
                }
            }
        }
        return isFull;
    }
    public static double[] Normalization()
    {
        var Inputs = new double[9];
        int index = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                switch (MainMatrix[row, column])
                {
                    case 'X':
                        Inputs[index] = 1.0;
                        break;
                    case 'O':
                        Inputs[index] = 0.0;
                        break;
                    case '#':
                        Inputs[index] = 0.5;
                        break;
                }
                index++;
            }
        }
        return Inputs;
    }
}
