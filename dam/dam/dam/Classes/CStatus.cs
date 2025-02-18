namespace dam;

using System.Drawing;

public class CStatus : IStatus
{
    private readonly Point _position = new Point(5, 18);
    
    private readonly ITurnController _turnController;
    private readonly IScoreboard _scoreboard;
    
    public CStatus(
        ITurnController turnController,
        IScoreboard scoreboard
    )
    {
        _turnController = turnController;
        _scoreboard = scoreboard;
    }

    public void Render(string message)
    {
        ClearStatus();
        int currentHeight = 0;
        Console.SetCursorPosition(_position.X, _position.Y + currentHeight++);
        Console.WriteLine(_turnController.IsPlayer1Turn ? $"{_scoreboard.GetPlayers()[0].Name}'s turn (Red)" : $"{_scoreboard.GetPlayers()[1].Name}'s turn (Green)");
        
        Console.SetCursorPosition(_position.X, _position.Y + currentHeight++);
        Console.Write(message);
    }

    public void ShowError(string message)
    {
        int currentHeight = 3;
        Console.SetCursorPosition(_position.X, _position.Y + currentHeight++);
        Console.Write(message);
    }
    
    public void ClearStatus()
    {
        int currentHeight = 0;
        for(int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(_position.X, _position.Y + currentHeight++);
            Console.Write(new string(' ', 50));
        }
    }
}