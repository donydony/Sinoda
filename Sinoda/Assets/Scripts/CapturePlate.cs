using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePlate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
            this.slots[i] = new Piece(this.owner, i);
            this.slots[i].value = 0;
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
