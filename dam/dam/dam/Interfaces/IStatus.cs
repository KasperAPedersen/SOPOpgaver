namespace dam;

public interface IStatus
{
    void Render(string message);
    void ShowError(string message);
    void ClearStatus();
}