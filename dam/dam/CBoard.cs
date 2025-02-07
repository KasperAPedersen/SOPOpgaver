namespace dam;

public class CBoard
{
    public enum SquareState
    {
        Empty,
        Player1,
        Player2
    }

    private const int BoardSize = 8;
    private List<SquareState>[,] board;

    public CBoard()
    {
        board = new List<SquareState>[BoardSize, BoardSize];
        InitializeBoard();
    }

    public int Size => BoardSize;

    private void InitializeBoard()
    {
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                board[row, col] = new List<SquareState>();
                if ((row + col) % 2 == 0) // only use dark squares
                {
                    continue;
                }

                if (row < 3) // Add player 1 pieces
                {
                    board[row, col].Add(SquareState.Player1);
                }
                else if (row > 4) // Add player 2 pieces
                {
                    board[row, col].Add(SquareState.Player2);
                }
            }
        }
    }
    
    public SquareState? GetSquareOwner(int row, int col)
    {
        if (board[row, col].Count == 0)
        {
            return null;
        }
        return board[row, col].Last();
    }
    
    public bool IsSquareEmpty(int row, int col)
    {
        return board[row, col].Count == 0;
    }
    
    public bool IsOneSquareMove(int fromRow, int fromCol, int toRow, int toCol)
    {
        int rowDistance = Math.Abs(toRow - fromRow);
        int colDistance = Math.Abs(toCol - fromCol);
        return rowDistance == 1 && colDistance == 1;
    }
    
    public bool IsValidSkipMove(int fromRow, int fromCol, int toRow, int toCol, SquareState player)
    {
        int rowDistance = Math.Abs(toRow - fromRow);
        int colDistance = Math.Abs(toCol - fromCol);

        if (rowDistance == 2 && colDistance == 2)
        {
            int middleRow = (fromRow + toRow) / 2;
            int middleCol = (fromCol + toCol) / 2;
            var middleSquareOwner = GetSquareOwner(middleRow, middleCol);

            if (middleSquareOwner.HasValue && middleSquareOwner.Value != player && middleSquareOwner.Value != SquareState.Empty)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool HasPossibleSkipMove(int row, int col, SquareState owner)
    {
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
    
    public void RemovePiece(int row, int col)
    {
        if (board[row, col].Count > 0)
        {
            board[row, col].RemoveAt(board[row, col].Count - 1);
        }
    }
    
    public void MovePiece(int fromRow, int fromCol, int toRow, int toCol)
    {
        if (board[fromRow, fromCol].Count > 0)
        {
            var piece = board[fromRow, fromCol].Last();
            board[fromRow, fromCol].RemoveAt(board[fromRow, fromCol].Count - 1);
            board[toRow, toCol].Add(piece);
        }
    }

    public void Render()
    {
        Console.WriteLine("  A B C D E F G H");
        for (int row = BoardSize - 1; row >= 0; row--)
        {
            Console.Write($"{row + 1} ");
            for (int col = 0; col < BoardSize; col++)
            {
                Console.BackgroundColor = (row + col) % 2 == 0 ? ConsoleColor.White : ConsoleColor.Black;
                if (board[row, col].Count > 0)
                {
                    var piece = board[row, col].Last();
                    Console.ForegroundColor = piece == SquareState.Player1 ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.Write($"{board[row, col].Count} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("  ");
                }
                Console.ResetColor();
            }
            Console.Write($" {row + 1}");
            Console.WriteLine();
        }
        Console.WriteLine("  A B C D E F G H");
    }
}