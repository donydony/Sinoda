namespace FinalProject;

public class Slots
{
    public int id;
    public bool havePiece;
    public Piece piece;
    public Slots(int id)
    {
        this.id = id;
        this.havePiece = false;
    }
}