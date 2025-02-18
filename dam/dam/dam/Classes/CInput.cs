namespace dam;

public class CInput : IInput
{
    public (int fromRow, int fromCol, int toRow, int toCol)? ParseMove(int? initialRow = null, int? initialCol = null)
    {
        var from = initialRow.HasValue && initialCol.HasValue
            ? (initialRow.Value, initialCol.Value)
            : ParsePosition(UserInput("Select piece (e.g., A3): "));

        var to = ParsePosition(UserInput("Select destination (e.g., A3): "));

        if (from == null || to == null)
            return null;

        return (from.Value.row, from.Value.col, to.Value.row, to.Value.col);
    }

    private string UserInput(string text)
    {
        Console.SetCursorPosition(50, 5);
        Console.Write(text);
        string tmp;
        do
        {
            tmp = Console.ReadLine()?.ToUpper();

            if (!(tmp == null || tmp.Length != 2 || tmp[0] < 'A' || tmp[0] > 'H' || tmp[1] < '1' || tmp[1] > '8'))
                break;

            Console.SetCursorPosition(50, 7);
            Console.WriteLine("Invalid input. Please enter a valid square (e.g., A3).");
            Console.SetCursorPosition(50, 5);
            Console.Write(new string(' ', Console.WindowWidth - 50));
            Console.SetCursorPosition(50, 5);
            Console.Write(text);
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