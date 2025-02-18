namespace dam;

public class CBoard : IBoard
{
    private const int BoardSize = 8;
    private List<CPiece>[,] board;

    public CBoard()
    {
        board = new List<CPiece>[BoardSize, BoardSize];
        InitializeBoard();
    }

    public int Size => BoardSize;
    
    public void InitializeBoard()
    {
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                board[row, col] = new List<CPiece>();
                if ((row + col) % 2 != 0) // only use dark squares
                    continue;

                if (row < 3) // Add player 1 pieces
                {
                    board[row, col].Add(new CPiece(Owner.Player1));
                }
                else if (row > 4) // Add player 2 pieces
                {
                    board[row, col].Add(new CPiece(Owner.Player2));
                }
            }
        }
    }
    
    public Owner? GetSquareOwner(int row, int col)
    {
        if (row < 0 || row >= BoardSize || col < 0 || col >= BoardSize)
            return null;

        if (board[row, col].Count == 0)
            return null;
        
        return board[row, col].Last().PieceOwner;
    }

    public bool IsSquareEmpty(int row, int col)
    {
        return board[row, col].Count == 0;
    }

    public CPiece GetPiece(int row, int col)
    {
        return board[row, col].Last();
    }

    public void RemovePiece(int row, int col)
    {
        if (board[row, col].Count > 0)
            board[row, col].RemoveAt(board[row, col].Count - 1);
    }
    
    public void MovePiece(int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[fromRow, fromCol].Count > 0)
        {
            var piece = board[fromRow, fromCol].Last();
            board[fromRow, fromCol].RemoveAt(board[fromRow, fromCol].Count - 1);

            // Promote to king if reaching the opposite end
            if ((piece.PieceOwner == Owner.Player1 && toRow == BoardSize - 1) || (piece.PieceOwner == Owner.Player2 && toRow == 0))
            {
                piece.PromoteToKing();
            }

            board[toRow, toCol].Add(piece);

            // Remove the skipped piece
            if (Math.Abs(toRow - fromRow) == 2 && Math.Abs(toCol - fromCol) == 2)
            {
                int skippedRow = (fromRow + toRow) / 2;
                int skippedCol = (fromCol + toCol) / 2;
                RemovePiece(skippedRow, skippedCol);
            }
        }
    }
}