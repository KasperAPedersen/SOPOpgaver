﻿namespace dam;

public class CMove : IMove
{
    private readonly IBoard board;

    public CMove(IBoard board)
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

            // Check if middle and destination squares are within bounds
            if (middleRow < 0 || middleRow >= board.BoardSize || middleCol < 0 || middleCol >= board.BoardSize ||
                toRow < 0 || toRow >= board.BoardSize || toCol < 0 || toCol >= board.BoardSize)
                return false;

            var middleSquareOwner = board.GetSquareOwner(middleRow, middleCol);

            if (middleSquareOwner.HasValue && middleSquareOwner.Value != player)
            {
                if (board.IsSquareEmpty(toRow, toCol)) // Check if the destination square is empty
                    return true;
            }
        }
        return false;
    }
    
    public bool HasPossibleSkipMove(int row, int col, Owner owner)
    {
        if (row == 1 || row == board.BoardSize - 2) // Check if the piece is on the second last row
            return false;

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

            // Check if newRow and newCol are within bounds
            if (newRow >= 0 && newRow < board.BoardSize && newCol >= 0 && newCol < board.BoardSize)
            {
                if (IsValidSkipMove(row, col, newRow, newCol, owner))
                    return true;
            }
        }

        return false;
    }
}