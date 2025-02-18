namespace dam;

public class CRender : IRender
{
    private readonly IBoard _board;

    public CRender(IBoard board)
    {
        _board = board;
    }
    
    public void Render()
    {
        Console.WriteLine("  A B C D E F G H");
        for (int row = _board.Size - 1; row >= 0; row--)
        {
            Console.Write($"{row + 1} ");
            for (int col = 0; col < _board.Size; col++)
            {
                Console.BackgroundColor = (row + col) % 2 != 0 ? ConsoleColor.White : ConsoleColor.Black;
                if (!_board.IsSquareEmpty(row, col))
                {
                    var piece = _board.GetPiece(row, col);
                    Console.ForegroundColor = piece.PieceOwner == Owner.Player1 ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.Write(piece.PieceType == Type.King ? "K " : "O ");
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