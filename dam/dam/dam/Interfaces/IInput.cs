namespace dam;

public interface IInput
{
    (int fromRow, int fromCol, int toRow, int toCol)? ParseMove(int? initialRow = null, int? initialCol = null);
}