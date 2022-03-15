using UnityEngine;

public class FourPlayerConfiguration
{
    private int[,] initialPieces;

    public FourPlayerConfiguration()
    {
        this.initialPieces = new int[,]
        {
            {1, 2, 3, 9, 10, 11},
            {25, 26, 27, 36, 37, 38},
            {19, 17, 18, 28, 29, 30},
            {44, 45, 46, 52, 53, 54}
        };
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void load(Slots[] slots, Piece [] pieces)
    {
        Debug.Log(slots.Length);
        for (int i = 0; i < 4; i+=1)
        {
            for (int j = 0; j < 6; j+=1)
            {
                Debug.Log(i + " ," + j + " Results in " + this.initialPieces[i, j]);
                slots[this.initialPieces[i, j]].havePiece = true; // slot now know a piece is on it 
                slots[this.initialPieces[i, j]].piece = pieces[(i * 6) + j]; // slot now contains a reference to the piece on it 
                slots[this.initialPieces[i, j]].piece.slot = this.initialPieces[i, j]; // piece now knows which slot it is on
            }
        }
    }
}
