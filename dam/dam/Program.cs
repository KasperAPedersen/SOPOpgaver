namespace dam;

class Program
{
    static void Main(string[] args)
    {
        /*Console.Write("Enter name of player 1: ");
        string player1 = Console.ReadLine() ?? "Player 1";
        Console.Write("Enter name of player 2: ");
        string player2 = Console.ReadLine() ?? "Player 2";*/
        
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
}