namespace dam;

public class CPlayer
{
    static int amountOfPlayers = 0;
    public string Name { get; set; } = "Player";
    public int Score { get; set; } = 0;
    private int PlayerIndex { get; set; } = ++amountOfPlayers;

    public List<List<bool>> Pieces { get; set; }

    internal void UpdateScore(int score)
    {
        CScore.DrawScore(PlayerIndex, Name, score);
    }
}

public class CPlayerBuilder
{
    private CPlayer player;
    
    public CPlayerBuilder()
    {
        player = new CPlayer();
    }
    
    public CPlayerBuilder SetName(string name)
    {
        player.Name = name;
        return this;
    }
    
    public CPlayerBuilder SetScore(int score)
    {
        player.Score = score;
        return this;
    }
    
    public CPlayerBuilder SetPieces(List<List<bool>> pieces)
    {
        player.Pieces = pieces;
        return this;
    }
    
    public CPlayer Build()
    {
        return player;
    }
}