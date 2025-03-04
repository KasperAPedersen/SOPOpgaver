namespace dam;

public interface IRender
{
    void Render();
    void RenderSelectedPiece(int row, int col);
    void RenderSelector(int row, int col);
}