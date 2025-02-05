namespace dam;

using System.Drawing;

/*
    
    CBoard
        - Draw board
    CScore
        - Draw scoreboard
    CPlayer
        - Draw player pieces
        - Save player score
    CGame
        - Game logic 
    
 */
class Program
{
    static void Main(string[] args)
    {
        CBoard board = new CBoardBuilder()
            .SetStartPosition(new Point(2, 1))
            .Build();
        
        board.Render();
        
        Console.ReadKey();
    }
}