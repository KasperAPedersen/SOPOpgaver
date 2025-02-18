namespace dam;

public class CRender
{
    private readonly CBoard board;

    public CRender(CBoard board)
    {
        this.board = board;
    }
    
    public void Render()
    {
        Console.WriteLine("  A B C D E F G H");
        for (int row = board.Size - 1; row >= 0; row--)
        {
            Console.Write($"{row + 1} ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.BackgroundColor = (row + col) % 2 != 0 ? ConsoleColor.White : ConsoleColor.Black;
                if (!board.IsSquareEmpty(row, col))
                {
                    var piece = board.GetPiece(row, col);
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