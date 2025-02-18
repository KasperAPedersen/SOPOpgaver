namespace dam;

public class CInput : IInput
{
    private readonly IStatus _status;
    
    public CInput(IStatus status)
    {
        _status = status;
    }
    
    public (int fromRow, int fromCol, int toRow, int toCol)? ParseMove(int? initialRow = null, int? initialCol = null)
    {
        var from = initialRow.HasValue && initialCol.HasValue
            ? (initialRow.Value, initialCol.Value)
            : ParsePosition(UserInput("Select piece (e.g., A3): "));
        
        // Make the selected piece blink
        if (from != null)
        {
            // get the position f the selected piece
            Console.SetCursorPosition(from.Value.col, from.Value.row);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        
        var to = ParsePosition(UserInput("Select destination (e.g., A3): "));

        if (from == null || to == null)
            return null;

        return (from.Value.row, from.Value.col, to.Value.row, to.Value.col);
    }

    private string UserInput(string text)
    {
        _status.Render(text);
        string tmp;
        do
        {
            tmp = Console.ReadLine()?.ToUpper();

            if (!(tmp == null || tmp.Length != 2 || tmp[0] < 'A' || tmp[0] > 'H' || tmp[1] < '1' || tmp[1] > '8'))
                break;

            _status.ShowError("Invalid input. Please enter a valid square (e.g., A3).");
            _status.Render(text);
        } while (true);

        return tmp;
    }

    private (int row, int col)? ParsePosition(string pos)
    {
        if (pos.Length != 2) return null;

        int col = pos[0] - 'A';
        int row = pos[1] - '1';
        if (col < 0 || col >= 8 || row < 0 || row >= 8) return null;

        return (row, col);
    }
}