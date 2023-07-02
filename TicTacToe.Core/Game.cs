namespace TicTacToe.Core;

public enum GameState
{
    Started,
    Aborted,
    NotStarted,
    FinishedByDraw,
    FinishedByXWin,
    FinishedByOWin,
}

public class Game
{
    public GameState state = GameState.NotStarted;
    protected byte turn = 0;
    public Player? Winner;

    public static GameState CheckState(int turn)
    {
        if(Matrix.CheckVictory())
        {
            if(turn % 2 == 0) return GameState.FinishedByOWin;
            else return GameState.FinishedByXWin;
        }
        else if(Matrix.CheckFull())
        {
            return GameState.FinishedByDraw;
        } else return GameState.Started;
    }

    //public Game(Player first, Player second) => Start(first, second);

    public virtual void Start(Player first, Player second)
    {
        state = GameState.Started;

        Matrix.MakeEmpty();

        Player currentPlayer;
        while (!Matrix.CheckFull())
        {
            if (turn % 2 == 0) currentPlayer = first;
            else currentPlayer = second;

            //currentPlayer.MakeMove();
            turn++;

            if (Matrix.CheckVictory())
            {
                //state = GameState.FinishedByWin;
                Winner = currentPlayer;
                break;
            }
        }
        state = GameState.FinishedByDraw;
    }

}
