namespace dam;

public class CPlayer : IPlayer
{
    public string Name { get; set; }
    public int Score { get; set; }

    public CPlayer(string name)
    {
        Name = name;
        Score = 0;
    }
}