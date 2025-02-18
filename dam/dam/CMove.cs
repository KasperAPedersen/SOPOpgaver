namespace dam;

public class CMove
{
    private readonly CBoard board;

    public CMove(CBoard board)
    {
        this.board = board;
    }
    
    public bool IsOneSquareMove(int fromRow, int fromCol, int toRow, int toCol)
    {
        int rowDistance = Math.Abs(toRow - fromRow);
        int colDistance = Math.Abs(toCol - fromCol);
        return rowDistance == 1 && colDistance == 1;
    }
    
    public bool IsValidSkipMove(int fromRow, int fromCol, int toRow, int toCol, Owner player)
    {
        int rowDistance = Math.Abs(toRow - fromRow);
        int colDistance = Math.Abs(toCol - fromCol);

        if (rowDistance == 2 && colDistance == 2)
        {
            int middleRow = (fromRow + toRow) / 2;
            int middleCol = (fromCol + toCol) / 2;
            var middleSquareOwner = board.GetSquareOwner(middleRow, middleCol);

            if (middleSquareOwner.HasValue && middleSquareOwner.Value != player)
            {
                // Check if the destination square is empty
                if (board.IsSquareEmpty(toRow, toCol))
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    public bool HasPossibleSkipMove(int row, int col, Owner owner)
    {
        // Check if the piece is on the second last row
        if (row == 1 || row == board.Size - 2)
        {
            return false;
        }

        // Check all possible skip directions
        int[][] directions = new int[][]
        {
            new int[] { -2, -2 }, new int[] { -2, 2 },
            new int[] { 2, -2 }, new int[] { 2, 2 }
        };

        foreach (var direction in directions)
        {
            int newRow = row + direction[0];
            int newCol = col + direction[1];
            if (IsValidSkipMove(row, col, newRow, newCol, owner))
            {
                return true;
            }
        }

        return false;
    }
}