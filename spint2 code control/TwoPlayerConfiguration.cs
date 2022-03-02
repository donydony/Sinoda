namespace FinalProject;

public class TwoPlayerConfiguration
{
    private int[,] initialPieces;

    public TwoPlayerConfiguration()
    {
        this.initialPieces = new int[,]
        {
            {3, 4, 5, 9, 10, 11},
            {14, 15, 16, 20, 21, 22}
        };
    }

    public void load(Slots[] slots, Piece [] pieces)
    {
        for (int i = 0; i < this.initialPieces.Length; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                slots[this.initialPieces[i, j]].havePiece = true; // slot now know a piece is on it 
                slots[this.initialPieces[i, j]].piece = pieces[(i * 6) + j]; // slot now contains a reference to the piece on it 
                slots[this.initialPieces[i, j]].piece.slot = this.initialPieces[i, j]; // piece now knows which slot it is on
            }
        }
    }

    
}