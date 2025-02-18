namespace dam;

public enum Type
    {
        Normal,
        King
    }
    
    public enum Owner
    {
        Player1,
        Player2
    }

public class Piece
{
    public Type PieceType { get; private set; }
    public Owner PieceOwner { get; private set; }

    public Piece(Owner owner, Type type = Type.Normal)
    {
        PieceOwner = owner;
        PieceType = type;
    }

    public void PromoteToKing()
    {
        PieceType = Type.King;
    }
}