namespace FinalProject;

public class CapturePlate
{
    public int owner;
    public Piece[] slots = new Piece[6];
    private int pieceCount;
    private int score;
    
    
    public CapturePlate(int id)
    {
        this.owner = id;
        this.pieceCount = 0;
        this.score = 0;
        for (int i = 0; i < 6; i++)
        {
            slots[i].value = 0;
        }
    }

    public void addPiece(Piece p)
    {
        if (this.pieceCount < 6)
        {
            this.slots[pieceCount] = p;
            
        }
    }

    public void updateScore()
    {
        this.score = 0;
        for (int i = 0; i < pieceCount; i++)
        {
            score += this.slots[i].value;

        }
    }

    public int getScore()
    {
        return this.score;
    }


}