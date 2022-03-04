
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int id;
    public bool havePiece;
    public Piece piece;
    public int[] adjcents = new int[3];
    public Slots(int id)
    {
        this.id = id;
        this.havePiece = false;
    }
}
