namespace dam;

public struct Player(string name)
{
    internal string Name { get; set; } = name;
    internal int Score { get; set; } = 0;
}

class Program
{
    static void Main(string[] args)
    {
        /*Console.Write("Enter name of player 1: ");
        string player1 = Console.ReadLine() ?? "Player 1";
        Console.Write("Enter name of player 2: ");
        string player2 = Console.ReadLine() ?? "Player 2";*/
        CGame game = new ();
        game.Start();
    }
}