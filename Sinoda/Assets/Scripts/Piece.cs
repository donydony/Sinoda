using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
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
    public int slot;
    public int value;
    public int owner;
    
    
    public Piece(int id, int owner)
    {
        this.id = id;
        this.slot = -1;
        this.value = 1;
        this.owner = owner; 
        // the owner of this piece
        // determain the color of the piece                    

    } 

    public void increaseValue()
    {
        this.value++;
    }
}
