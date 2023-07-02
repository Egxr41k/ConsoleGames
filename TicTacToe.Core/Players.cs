using System.Linq.Expressions;

namespace TicTacToe.Core;
abstract public class Player
{
    public string Name;
    public string PlayingChar;
    protected int FirstIndex, SecondIndex;

    public abstract void MakeMove();

    public void SafeMove(Action MakeMove)
    {
        do MakeMove();
        while (!Matrix.CheckIndexes(FirstIndex, SecondIndex));
        Matrix.MainMatrix[FirstIndex][SecondIndex] = PlayingChar;
    }


    public Player(string playingChar, string name = "undefined")
    {
        Name = name;
        PlayingChar = playingChar;
    }
}

public class RndMoves : Player
{
    readonly Random random = new();
    public RndMoves(string playingChar, string name = "RndMoves")
        : base(playingChar, name)
    {

    }

    public override void MakeMove()
    {
        SafeMove(() =>
        {
            FirstIndex = random.Next(0, 3);
            SecondIndex = random.Next(0, 3);
        });
    }
}

public class AI : Player
{
    readonly NeuralNetwork nn = new(0.1);
    public AI(string playingChar, string name = "AI")
        : base(playingChar, name)
    {

    }

    public override void MakeMove()
    {
        SafeMove(() =>
        {
            var result = nn.FeedForward();
            FirstIndex = result[0]; 
            SecondIndex = result[1];
        });
    }
}
