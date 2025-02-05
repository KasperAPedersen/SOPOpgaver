namespace dam;

using System.Drawing;

public static class CScore
{
    static public Point StartPosition { get; set; }
    static int height = 4;
    static int width = 20;
    static int border = 1;
    
    static public void Render()
    {
        DrawBorder();
    }
    
    static public void DrawScore(int pos, string name = "Player", int score = 0)
    {
        Console.SetCursorPosition(StartPosition.X + border + 2, StartPosition.Y + border + pos);
        Console.Write($"{name}: {score}");
    }
    
    static void DrawBorder()
    {
        Console.SetCursorPosition(StartPosition.X, StartPosition.Y);
        Console.BackgroundColor = ConsoleColor.DarkGray;

        Console.Write(new string(' ', border));
        for (int i = 0; i < width; i++) Console.Write(" ");
        Console.Write(new string(' ', border));

        for (int i = 0; i < height; i++)
        {
            Console.SetCursorPosition(StartPosition.X, StartPosition.Y + 1 + i);
            
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write( new string(' ', border) );
            Console.ResetColor();
            Console.Write( new string(' ', width) );
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write( new string(' ', border) );
        }
        
        Console.SetCursorPosition(StartPosition.X, StartPosition.Y + border + height);
        
        Console.Write(new string(' ', border));
        for (int i = 0; i < width; i++) Console.Write(" ");
        Console.Write(new string(' ', border));
        
        
        Console.ResetColor();
    }
}