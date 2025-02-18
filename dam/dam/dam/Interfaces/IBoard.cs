namespace dam;

public interface IBoard
{
    int Size { get; }
    void InitializeBoard();
    Owner? GetSquareOwner(int row, int col);
    bool IsSquareEmpty(int row, int col);
    CPiece GetPiece(int row, int col);
    void RemovePiece(int row, int col);
    void MovePiece(int fromRow, int fromCol, int toRow, int toCol);
}