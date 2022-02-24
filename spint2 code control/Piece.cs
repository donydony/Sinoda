namespace FinalProject;

public class Piece
{
    public int id;
    public int[] adjcents = new int[3];
    public int value;
    public int owner;
    
    
    public Piece(int id, int owner, int adj1, int adj2, int adj3)
    {
        this.id = id;
        this.adjcents[0] = adj1;
        this.adjcents[1] = adj2;
        this.adjcents[2] = adj3;
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