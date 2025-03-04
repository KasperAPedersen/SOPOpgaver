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

        while (true)
        {
            _render.RenderSelector(_selectedRow, _selectedCol);
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (_selectedRow < _board.Size - 1) _selectedRow++;
                    break;
                case ConsoleKey.DownArrow:
                    if (_selectedRow > 0) _selectedRow--;
                    break;
                case ConsoleKey.LeftArrow:
                    if (_selectedCol > 0) _selectedCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (_selectedCol < _board.Size - 1) _selectedCol++;
                    break;
                case ConsoleKey.Enter:
                    var from = (_selectedRow, _selectedCol);
                    _render.RenderSelectedPiece(_selectedRow, _selectedCol);
                    var to = GetDestination();
                    if (to != null)
                        return (from.Item1, from.Item2, to.Value.row, to.Value.col);
                    break;
            }
            //
        }
    }

    private (int row, int col)? GetDestination()
    {
        while (true)
        {
            _render.RenderSelector(_selectedRow, _selectedCol);
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (_selectedRow < _board.Size - 1) _selectedRow++;
                    break;
                case ConsoleKey.DownArrow:
                    if (_selectedRow > 0) _selectedRow--;
                    break;
                case ConsoleKey.LeftArrow:
                    if (_selectedCol > 0) _selectedCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (_selectedCol < _board.Size - 1) _selectedCol++;
                    break;
                case ConsoleKey.Enter:
                    return (_selectedRow, _selectedCol);
            }
        }
    }
}