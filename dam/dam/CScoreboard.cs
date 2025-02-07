namespace dam;

using System.Drawing;

public class CScoreboard
{
    private List<Player> players = [];
    private int width = 20;
    private Point Position = new Point(50, 0); 
    
    public CScoreboard(List<Player> players)
    {
        this.players = players;
    }

    internal void Render()
    {
        int currentHeight = 0;
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine("┌" + new string('─', width - 2) + "┐");
        
        for(int i = 0; i < players.Count; i++)
        {
            var player = players[i];
            Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
            Console.WriteLine($"│ {player.Name}: {player.Score}{new string(' ', width - 6 - player.Name.Length - player.Score.ToString().Length)} │"); // 6 = 2 spaces + 2 colons + 2 spaces
        }
        
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine("└" + new string('─', width - 2) + "┘");
    }
}