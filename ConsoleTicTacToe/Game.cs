namespace ConsoleTicTacToe;

public delegate void IndexGeneration();
class Game
{
    protected byte Turn = 1;
    protected char LastChar;
    //private string Player1, Player2;
    protected int FirstIndex, SecondIndex;
    //Topology topology = new(9, 9, 0.1, 3);
    //rotected NeuralNetworks.NeuralNetwork nn = new(new(9, 9, 0.1, 3));
    protected NeuralNetwork nn = new NeuralNetwork(0.1);

    
    IndexGeneration p1Generation;
    IndexGeneration p2Generation;
    protected bool CheckIndex()
    {
        bool WrongIndexes = false;
        if (Matrix.MainMatrix[FirstIndex, SecondIndex] != '#')
        {
            WrongIndexes = true;
        }
        return WrongIndexes;
    }

    #region IndexGeneration
    private void InputIndexGeneration()
    {
        Console.WriteLine($"ход играющего за {LastChar}");
        Console.WriteLine("введите адрес клетки для вашего символа");

        FirstIndex = Convert.ToInt32(Console.ReadLine());
        SecondIndex = Convert.ToInt32(Console.ReadLine());
    }
    protected void RndIndexGeneration()
    {
        Random random = new Random();
        FirstIndex = random.Next(0, 3);
        SecondIndex = random.Next(0, 3);
    }
    protected void NNIndexGeneration()
    {
        nn.FeedForward();
        
        FirstIndex = nn.FirstIndex;
        SecondIndex = nn.SecondIndex;

    }
    #endregion
    protected double[] Normalization()
    {
        var Inputs = new double[9];
        int index = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                switch (Matrix.MainMatrix[row, column])
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
    public virtual void MakeTurn(IndexGeneration generation, char LastChar)
    {
        Matrix.Print();

        generation();
        while (CheckIndex()) 
        {
            if(generation == NNIndexGeneration)
            {
                //nn.Init();
            }
            generation();
        }
        this.LastChar = LastChar;
        Matrix.MainMatrix[FirstIndex, SecondIndex] = LastChar;
        Turn++;
    }
    private void SelectPlayer(string playernum, ref IndexGeneration generation)
    {

        Console.WriteLine($"Select the {playernum} player: 1 - human, 2 - neuralnetwork");
        int p = Convert.ToInt32(Console.ReadLine());
        switch (p)
        {
            case 1:
                generation = InputIndexGeneration;
                break;
            case 2:
                generation = NNIndexGeneration;
                break;
            case 3:
                generation = RndIndexGeneration;
                break;
        }
    }
    private void SelectMode()
    {
        SelectPlayer("first",ref p1Generation);
        SelectPlayer("second",ref p2Generation);
    }
    public virtual void NewGame()
    {
        Matrix.MakeEmpty();
        SelectMode();

        while (!Matrix.CheckFull() && !Matrix.CheckVictory())
        {
            if (Turn % 2 == 0) MakeTurn(p1Generation, 'X');
            else MakeTurn(p2Generation, 'O');
            if (Matrix.CheckVictory()) Console.WriteLine($"Winnner is {LastChar}");
        }

        Console.WriteLine("игра окончена");
    }

}
