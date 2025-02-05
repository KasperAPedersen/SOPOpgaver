namespace dam;

using System.Drawing;

public class CBoard
{
    public Point StartPosition { get; set; }
    private int border = 1, width = 8, height = 8;
    
    public CBoard()
    {
        
    }

    internal void Render()
    {
        DrawBorder();
        DrawPlayableBoard();
    }

    internal void DrawPlayableBoard()
    {
        Console.SetCursorPosition(StartPosition.X + border, StartPosition.Y + border);
        int currentHeight = 0;
        for(int i = 0; i < height; i++)
        {
            for (int o = 0; o < width; o++)
            {
                if(o % 2 == 0 && i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else if(o % 2 != 0 && i % 2 != 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(" ");
            }
            Console.SetCursorPosition(StartPosition.X + border, StartPosition.Y + border + ++currentHeight);
        }
    }

    internal void DrawBorder()
    {
        Console.SetCursorPosition(StartPosition.X, StartPosition.Y);
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write(new string(' ', border));
        for (int i = 0; i < width; i++) Console.Write(( (char)('a' + i)).ToString().ToUpper() );
        Console.Write(new string(' ', border));

        for (int i = 0; i < height; i++)
        {
            Console.SetCursorPosition(StartPosition.X, StartPosition.Y + 1 + i);
            Console.Write( (i + 1) + new string(' ', width) + (i + 1));
        }
        
        Console.SetCursorPosition(StartPosition.X, StartPosition.Y + border + height);
        
        Console.Write(new string(' ', border));
        for (int i = 0; i < width; i++) Console.Write(( (char)('a' + i)).ToString().ToUpper() );
        Console.Write(new string(' ', border));
        
        
        Console.ResetColor();
    }
}

public class CBoardBuilder
{
    private CBoard Board { get; set; }
    public CBoardBuilder()
    {
        Board = new CBoard();
    }
    
    public CBoardBuilder SetStartPosition(Point pos)
    {
        Board.StartPosition = pos;
        return this;
    }
    
    public CBoard Build()
    {
        return Board;
    }
}