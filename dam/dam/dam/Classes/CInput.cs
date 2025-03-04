namespace dam;

public class CInput : IInput
{
    private readonly IStatus _status;
    private readonly IRender _render;
    private readonly IBoard _board;
    private int _selectedRow;
    private int _selectedCol;

    public CInput(IStatus status, IRender render, IBoard board)
    {
        _status = status;
        _render = render;
        _board = board;
        _selectedRow = 0;
        _selectedCol = 0;
    }

    public (int fromRow, int fromCol, int toRow, int toCol)? ParseMove(int? initialRow = null, int? initialCol = null)
    {
        _selectedRow = initialRow ?? 3;
        _selectedCol = initialCol ?? 3;
        
        (int row, int col)? from = 
            initialRow.HasValue && initialCol.HasValue ? 
                (initialRow.Value, initialCol.Value) : 
                Select("Select piece to move");
        
        _render.RenderSelectedPiece(_selectedRow, _selectedCol);
        var to = Select("Select destination square");
        if (to != null) return (from.Value.row, from.Value.col, to.Value.row, to.Value.col);
        
        return ParseMove(from?.row, from?.col);
    }
    
    private (int row, int col)? Select(string message)
    {
        _status.Render(message);
        return Navigate();
    }

    private (int row, int col)? Navigate()
    {
        while (true)
        {
            _render.RenderSelector(_selectedRow, _selectedCol);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (_selectedRow < _board.Size - 1) _selectedRow++;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (_selectedRow > 0) _selectedRow--;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (_selectedCol > 0) _selectedCol--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (_selectedCol < _board.Size - 1) _selectedCol++;
                    break;
                case ConsoleKey.Enter:
                    return (_selectedRow, _selectedCol);
            }
        }
    }
}