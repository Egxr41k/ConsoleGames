namespace ConsoleTicTacToe;
class DeepLearning : Game
{
    int victories, draws, loses;
    double response;
    public override void NewGame()
    {
        IndexGeneration neuralnetwork = NNIndexGeneration;
        IndexGeneration random = RndIndexGeneration;
        
        Matrix.MakeEmpty();
        while (!Matrix.CheckFull() && !Matrix.CheckVictory())
        {
            response = Turn / 10;
            if (Turn % 2 == 1 || Turn == 1)
            {
                MakeTurn(neuralnetwork, 'X');
                if (Matrix.CheckVictory())
                {
                    victories++;
                    response =+ 0.75;
                }
            }
            else
            {
                MakeTurn(random, 'O');
                if (Matrix.CheckVictory())
                {
                    loses++;
                    response =- 0.75;
                }
            }

            nn.Backpropogation(response);
        }
        
        
    }
    public override void MakeTurn(IndexGeneration generation, char LastChar)
    {
        //Matrix.Print();
        int AttmptCount = 1;
        generation();
        while (CheckIndex())
        {
            if (generation == NNIndexGeneration)
            {
                //nn.Init();
                response = 0.25;
                nn.Backpropogation(response);
            }
            generation();
            AttmptCount++;
        }
        
        Matrix.MainMatrix[FirstIndex, SecondIndex] = LastChar;
        Turn++;
    }

    public DeepLearning()
    {
        for (int t = 0; t < 10000; t++)
        {
            NewGame();
            //Console.WriteLine(t);
        }
        Statistics();
    }
    private void Statistics()
    {
        Console.WriteLine($"процент побед {victories/1000}%");
        //Console.WriteLine($"процент ничьих {draws}%");
        Console.WriteLine($"процент поражений {loses/1000}%");
    }
}
