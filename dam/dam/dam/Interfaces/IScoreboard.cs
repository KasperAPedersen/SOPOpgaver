namespace dam;

public interface IScoreboard
{
    void Render();
    List<CPlayer> GetPlayers();
}