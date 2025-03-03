﻿namespace dam;

using System.Drawing;

public class CRender : IRender
{
    private const bool largeBoard = true;
    
    private readonly IBoard _board;
    private readonly Point Position = new Point(0, 0);
    private const int squareWidth = largeBoard ? 11 : 9;
    private const int squareHeight = largeBoard ? 5 : 4;
    private int _previousRow = 0;
    private int _previousCol = 0;

    public CRender(IBoard board)
    {
        _board = board;
    }

    public void Render()
    {
        string padding = new string(' ', ((squareWidth - 1) / 2) - 1);
        string headerPadding = padding + padding;
        int currentHeight = 0;
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine($"  {padding}A {headerPadding}B {headerPadding}C {headerPadding}D {headerPadding}E {headerPadding}F {headerPadding}G {headerPadding}H ");
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
                            int pieceColor = piece.PieceOwner == Owner.Player1 ? 101 : 102;
                            Console.Write($"\u001b[0m  \u001b[{pieceColor}m" + new string(' ', squareWidth - 1 - 4) + "\u001b[0m  "); // horizontal line of piece
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
                        if (!_board.IsSquareEmpty(row, col) && i != 0 && i != squareHeight - 1)
                        {
                            var piece = _board.GetPiece(row, col);
                            int pieceColor = piece.PieceOwner == Owner.Player1 ? (piece.PieceType == Type.King ? 103 : 101) : (piece.PieceType == Type.King ? 103: 102);
                            Console.Write($"\u001b[0m  \u001b[{pieceColor}m" + new string(' ', squareWidth - 1 - 4) + "\u001b[0m  "); // vertical line of piece
                        }
                        else
                        {
                            Console.Write(new string(' ', squareWidth - 1));
                        }
                        Console.ResetColor();
                    }
                }
            }
        }
        
        Console.SetCursorPosition(Position.X, Position.Y + currentHeight++);
        Console.WriteLine($"  {padding}A {headerPadding}B {headerPadding}C {headerPadding}D {headerPadding}E {headerPadding}F {headerPadding}G {headerPadding}H ");
    }

    public void RenderSelectedPiece(int row, int col)
    {
        var realRow = _board.Size - (row + 1);
        for(int i = 0; i < squareHeight; i++)
        {
            if(i == 0 || i == squareHeight - 1) continue;
            
            Console.SetCursorPosition((Position.X + (col * (squareWidth - 1))) + 2, Position.Y + (realRow * squareHeight) + 1 + i);
            
            
            // Vertical
            Console.WriteLine("  \u001b[46m" + new string(' ', squareWidth - 5) + "\u001b[0m  ");
        }
        RenderSelector(row, col);
    }
    
    public void RenderSelector(int row, int col)
    {
        // Clear the previous selector
        ClearSelector(_previousRow, _previousCol);

        // Render the new selector
        var realRow = _board.Size - (row + 1);
        for (int i = 0; i < squareHeight; i++)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Position.X + (col * (squareWidth - 1))) + 2, Position.Y + (realRow * squareHeight) + 1 + i);
            if (i != 0 && i != squareHeight - 1)
            {
                Console.WriteLine("  ");
                Console.SetCursorPosition((Position.X + (col * (squareWidth - 1))) + 2 + squareWidth - 3, Position.Y + (realRow * squareHeight) + 1 + i);
                Console.WriteLine("  ");
                continue;
            }
            Console.WriteLine(new string(' ', squareWidth - 1));
            Console.ResetColor();
        }

        // Update the previous selector position
        _previousRow = row;
        _previousCol = col;
    }
    
    public void ClearSelector(int row, int col)
    {
        var realRow = _board.Size - (row + 1);
        for (int i = 0; i < squareHeight; i++)
        {
            Console.BackgroundColor = (row + col) % 2 != 0 ? ConsoleColor.White : ConsoleColor.Black;
            Console.SetCursorPosition((Position.X + (col * (squareWidth - 1))) + 2, Position.Y + (realRow * squareHeight) + 1 + i);
            if (i != 0 && i != squareHeight - 1)
            {
                Console.WriteLine("  ");
                Console.SetCursorPosition((Position.X + (col * (squareWidth - 1))) + 2 + squareWidth - 3, Position.Y + (realRow * squareHeight) + 1 + i);
                Console.WriteLine("  ");
                continue;
            }
            Console.WriteLine(new string(' ', squareWidth - 1));
            Console.ResetColor();
        }
    }
}