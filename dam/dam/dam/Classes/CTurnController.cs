namespace dam;

public class CTurnController : ITurnController
{
    public bool IsPlayer1Turn { get; private set; } = true;

    public void ToggleTurn() => IsPlayer1Turn = !IsPlayer1Turn;

    public bool IsForwardMove(int fromRow, int toRow, CPiece piece)
    {
        if (piece.PieceType == Type.King)
            return true; // Kings can move in any direction
        
        return IsPlayer1Turn ? toRow > fromRow : toRow < fromRow;
    }
}