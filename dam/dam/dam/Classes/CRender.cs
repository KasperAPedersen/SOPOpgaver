namespace dam;

using System.Drawing;

public class CRender : IRender
{
    private readonly IBoard _board;
    private readonly Point Position = new Point(0, 0);
    private const int squareWidth = 10;
    private const int squareHeight = 5;

    public CRender(IBoard board)
    {
        _board = board;
    }

    public void Render()
    {
        string padding = new string(' ', (squareWidth - 1) / 2);
        string headerPadding = padding + padding;
        int currentHeight = 0;
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine($"  {padding}A{headerPadding}B{headerPadding}C{headerPadding}D{headerPadding}E{headerPadding}F{headerPadding}G{headerPadding}H");
        for (int row = _board.Size - 1; row >= 0; row--)
        {
            for (int i = 0; i < squareHeight; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
                if (i == 2)
                {
                    Console.Write($"{row + 1} ");
                    for (int col = 0; col < _board.Size; col++)
                    {
                        Console.BackgroundColor = (row + col) % 2 != 0 ? ConsoleColor.White : ConsoleColor.Black;
                        if (!_board.IsSquareEmpty(row, col))
                        {
                            var piece = _board.GetPiece(row, col);
                            Console.ForegroundColor = piece.PieceOwner == Owner.Player1 ? ConsoleColor.Red : ConsoleColor.Green;
                            Console.Write(piece.PieceType == Type.King ? padding + "K" + padding : padding + "O" + padding);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(new string(' ', squareWidth - 1));
                        }
                        Console.ResetColor();
                    }
                    Console.Write($" {row + 1}");
                }
                else
                {
                    Console.Write("  ");
                    for (int col = 0; col < _board.Size; col++)
                    {
                        Console.BackgroundColor = (row + col) % 2 != 0 ? ConsoleColor.White : ConsoleColor.Black;
                        Console.Write(new string(' ', squareWidth - 1));
                        Console.ResetColor();
                    }
                }
            }
        }
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine($"  {padding}A{headerPadding}B{headerPadding}C{headerPadding}D{headerPadding}E{headerPadding}F{headerPadding}G{headerPadding}H");
    }

    public void RenderSelectedPiece(int row, int col)
    {
        
        // INCORRECT CURSOR POSITION
        Console.SetCursorPosition(Position.X + squareWidth * col + squareWidth / 2, Position.Y + squareHeight * (_board.Size - row) - squareHeight / 2);
        Console.Write("X");
    }
}