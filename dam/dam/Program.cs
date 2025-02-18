namespace dam;

using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        ServiceCollection serviceCollection = new();
        ConfigureServices(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var game = serviceProvider.GetService<CGame>();
        game.Start();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            var players = new List<CPlayer>
            {
                new CPlayer("Player 1"),
                new CPlayer("Player 2")
            };
            return players;
        });
        
        services.AddSingleton<IBoard, CBoard>();
        services.AddSingleton<IRender, CRender>();
        services.AddSingleton<IMove, CMove>();
        services.AddSingleton<IScoreboard, CScoreboard>();
        services.AddSingleton<ITurnController, CTurnController>();
        services.AddSingleton<IInput, CInput>();
        services.AddSingleton<IStatus, CStatus>();
        
        services.AddSingleton<CGame>();
    }
}

/*class Program
{
    static void Main(string[] args)
    {
        List<CPlayer> players = new();
        
        players.Add(new CPlayer("Player 1"));
        players.Add(new CPlayer("Player 2"));
        
        IBoard board = new CBoard();
        IRender boardRenderer = new CRender(board);
        IMove moveValidator = new CMove(board);
        IScoreboard scoreboard = new CScoreboard(players);
        ITurnController turnController = new CTurnController();
        IInput inputHandler = new CInput();
        
        CGame game = new (
            board,
            boardRenderer,
            moveValidator,
            scoreboard,
            turnController,
            inputHandler
        );
        game.Start();
    }
}*/