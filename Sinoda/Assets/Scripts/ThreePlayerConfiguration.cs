using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThreePlayerConfiguration
{
    private int[,] initialPieces;
    // Start is called before the first frame update
    public ThreePlayerConfiguration()
    {
        this.initialPieces = new int[,]
        {
            {3, 4, 5, 9, 10, 11},
            {14, 15, 13, 6, 7, 8},
            {16, 17, 18,22, 23, 24}
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
        for (int i = 0; i < 3; i+=1)
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
