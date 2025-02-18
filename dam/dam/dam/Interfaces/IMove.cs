namespace dam;

public interface IMove
{
    bool IsOneSquareMove(int fromRow, int fromCol, int toRow, int toCol);
    bool IsValidSkipMove(int fromRow, int fromCol, int toRow, int toCol, Owner player);
    bool HasPossibleSkipMove(int row, int col, Owner owner);
}