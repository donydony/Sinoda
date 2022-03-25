using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int id;
    public int slot;
    public int value;
    public int owner;
    public int turn;
    public Board board;
    public List<int> availablemoves;
    public Piece(int id, int owner)
    {
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

    public void SetData(Vector3 coords, int team,int v, int slo,int t, int index,Board b)
    {
        this.owner = team;
        this.slot = slo;
        this.value = v;
        this.turn = t;
        this.id = index;
        this.board = b;
        
        moveto(slo);
        

    }
    public bool rolldown()
    {
        if (this.value != 1)
        {
            this.value--;
            roll();
            return true;
        }
        return false;
        
    }
    public bool rollup()
    {
        if (this.value != 4)
        {
            this.value++;
            roll();
            return true;
        }
        return false;
    }
        public void roll()
    {
        
        if (this.value == 1)
        {
            if (this.turn == 1)
            {
                this.transform.eulerAngles = new Vector3(
                0f,
                180f,
                0f
            );
            }

            else
            {
                this.transform.eulerAngles = new Vector3(

               0f,
               0f,
               0f
                );
            }
        }
        // 2
        if (this.value == 2)
        {
            if (this.turn == 1)
            {
                this.transform.eulerAngles = new Vector3(
                0f,
                240f,
                -110f
            );
            }
            else
            {
                this.transform.eulerAngles = new Vector3(
                0f,
                60f,
                -110f
            );
            }

        }
        // 3
        if (this.value == 3)
        {
            if (this.turn == 1)
            {
                this.transform.eulerAngles = new Vector3(
                235f,
                211f,
                -55f
            );
            }
            else
            {
                this.transform.eulerAngles = new Vector3(
                235f,
                31f,
                -55f
            );
            }
            
        }


        // 4 
        if (this.value == 4)
        {
            if (this.turn == 1)
            {
                this.transform.eulerAngles = new Vector3(
                125f,
                150f,
                -55f
            );
            }
            else
            {
                this.transform.eulerAngles = new Vector3(
                125f,
                -30f,
                -55f
            );
            }
        }


    }

    public void moveto(int slot)
    {
        transform.position = board.GetPositionAtSlot(slot);
        this.slot = slot;

        this.turn = board.IfTurnAtSlot(slot);

        roll();
    }
    public void Selected(bool selected)
    {
        if (selected)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + 5,
                transform.position.z
                );
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - 5,
                transform.position.z
                );
        }
    }

    public void SelectPossibleMoves()
    {   //TODO
        availablemoves.Clear();
        int v = 0;
        availablemoves = Recursion(this.slot,v);

    }

    private List<int> Recursion(int s, int v)
    {
        List<int> result = new List<int>();
        if (s == -1)
        {
            return result;
        }
        if (v == this.value)
        {
            
            if (!board.hasfriendpiece(s, this.owner))
            {
                result.Add(s);
                
            }
            return result;
        }
        else
        {
            if (board.haspiece(s) && this!=board.GetPieceBySlot(s))
            {
                return result;

            }
        }
        int[] a = board.getadjacency(s);
        
        for(int i = 0; i < 3; i++)
        {

            result.AddRange(Recursion(a[i], v + 1));
                
            
        }
        return result;
    }

    
}
