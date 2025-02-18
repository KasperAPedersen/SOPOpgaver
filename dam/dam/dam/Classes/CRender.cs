namespace dam;

using System.Drawing;

public class CRender : IRender
{
    private readonly IBoard _board;
    private readonly Point Position = new Point(5, 7);

    public CRender(IBoard board)
    {
        _board = board;
    }
    
    public void Render()
    {
        int currentHeight = 0;
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine("  A B C D E F G H");
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
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
            Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        }
        Console.WriteLine("  A B C D E F G H");
    }

    public void RenderSelectedPiece(int row, int col)
    {
        Console.SetCursorPosition(Position.X + 2 * col + 2, Position.Y + _board.Size - row);
        Console.Write("\u001b[38;5;50m\u001b[5mO \u001b[0m");
    }
}