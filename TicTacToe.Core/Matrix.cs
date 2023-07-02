namespace TicTacToe.Core;

//public static enum MatrixState
//{
//    N
//}
public class Matrix
{

    // public static char[][] MainMatrix = new char[][]
    // {
    //     new char[]{' ', ' ', ' ' },
    //     new char[]{' ', ' ', ' ' },
    //     new char[]{' ', ' ', ' ' },

    // };

    public static string[][] MainMatrix = new string[][]
    {
        new string[]{" ", " ", " " },
        new string[]{" ", " ", " " },
        new string[]{" ", " ", " " },
    };
    

    public static void MakeEmpty()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                MainMatrix[row][column] = " ";
            }
        }
    } 
    
    public static bool CheckVictory()
    {
        bool Victory = false;
        if (//проверка по горизонтали
            MainMatrix[0][0] == MainMatrix[0][1] &&
            MainMatrix[0][0] == MainMatrix[0][2] &&
            MainMatrix[0][0] != " " ||      
            MainMatrix[1][0] == MainMatrix[1][1] &&
            MainMatrix[1][0] == MainMatrix[1][2] &&
            MainMatrix[1][0] != " " ||      
            MainMatrix[2][0] == MainMatrix[2][1] &&
            MainMatrix[2][0] == MainMatrix[2][2] &&
            MainMatrix[2][0] != " " ||      
            //проверка пo вертикали         
            MainMatrix[0][0] == MainMatrix[1][0] &&
            MainMatrix[0][0] == MainMatrix[2][0] &&
            MainMatrix[0][0] != " " ||      
            MainMatrix[0][1] == MainMatrix[1][1] &&
            MainMatrix[0][1] == MainMatrix[2][1] &&
            MainMatrix[0][1] != " " ||      
            MainMatrix[0][2] == MainMatrix[2][1] &&
            MainMatrix[2][0] == MainMatrix[2][2] &&
            MainMatrix[0][2] != " " ||
            // проверка по диагонали
            MainMatrix[0][0] == MainMatrix[1][1] &&
            MainMatrix[0][0] == MainMatrix[2][2] &&
            MainMatrix[0][0] != " " ||      
            MainMatrix[0][2] == MainMatrix[1][1] &&
            MainMatrix[0][2] == MainMatrix[2][0] &&
            MainMatrix[0][2] != " ") Victory = true;

        return Victory;
    }
    public static bool CheckFull()
    {
        bool isFull = true;
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (MainMatrix[row][column] == " ")
                {
                    isFull = false;
                    break;
                }
            }
        }
        return isFull;
    }

    public static bool CheckIndexes(int row, int column)
    {
        if (MainMatrix[row][column] == " ") return true;
        else return false;
    }

    
    public static double[] Normalization()
    {
        var Inputs = new double[9];
        int index = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                switch (MainMatrix[row][column])
                {
                    case "X":
                        Inputs[index] = 1.0;
                        break;
                    case "O":
                        Inputs[index] = 0.0;
                        break;
                    case " ":
                        Inputs[index] = 0.5;
                        break;
                }
                index++;
            }
        }
        return Inputs;
    }
}
