using TicTacToe.Core;

namespace TicTacToe.API;

class MinAPI : Game
{   
    // players creation
    Player ai, rnd;
    
    public MinAPI()
    {
        rnd = new RndMoves("O");
        ai = new AI("O");
    }
    
    public WebApplication Init(WebApplication app)
    {
        app.MapGet("/StartGame", async (context) =>
        {
            Matrix.MakeEmpty();
            state = GameState.Started;
            await Task.Run(() => DefaultResponce(context));
        });

        app.MapGet("/EndGame", async (context) =>
        {
            state = GameState.Aborted;
            await Task.Run(() => DefaultResponce(context));
        });

        app.MapPost("/MakeMove", async (context) =>
        {
            //synchronize
            var request = await context.Request.ReadFromJsonAsync<Body>();
            if (request != null)
            {
                Matrix.MainMatrix = request.gfield;
                turn++;
                state = Game.CheckState(turn);

                if(state == GameState.Started){
                    rnd.MakeMove();
                    turn++;
                    state = Game.CheckState(turn);
                }
                DefaultResponce(context);
            }
        });

        return app;
    }

    async void DefaultResponce(HttpContext context)
    {
        await context.Response.WriteAsJsonAsync(new object[]
        {
            Matrix.MainMatrix,
            state
        });
    }
}
record Body(string[][] gfield, GameState gstate);