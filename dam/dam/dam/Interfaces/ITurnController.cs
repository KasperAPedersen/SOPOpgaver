namespace dam;

public interface ITurnController
{
    bool IsPlayer1Turn { get; }
    void ToggleTurn();
    bool IsForwardMove(int fromRow, int toRow, CPiece piece);
}