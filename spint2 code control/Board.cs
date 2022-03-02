namespace FinalProject;

public class Board
{
    private int player_count;
    private Slots[] slots;
    private Player[] _players;
    private int turn;
    private int winner;
    
    
    public bool init()
    {
        for (int i = 0; i < 54; i++)
        {
            this.slots[i] = new Slots(i);
        }

        for (int i = 0; i < this.player_count; i++)
        {
            this._players[i] = new Player(i);
        }
        
        return true;
        
    }

    public Board(int playerCount)
    {
        this.turn = 0;
        this.player_count = playerCount;
        this.winner = -1;
        this._players = new Player[playerCount];
        if (playerCount > 3)
        {
            this.slots = new Slots[54];
        }
        else
        {
            this.slots = new Slots[24];
        }
        if (!this.init())
        {
           // fail for some reason 
        }
        
    }
    
    public void passTurn()
    {
        turn = (turn + 1) % this.player_count;
    }

    
    public bool getSlotOccupancy(int id)
    {
        return this.slots[id].havePiece;
        
    }

    public int getSlotPieceOwner(int id)
    {
        if (!this.slots[id].havePiece)
        {
            return -1;
        }
        return this.slots[id].piece.owner;
    }

    public int getCurrentPlayer()
    {
        return this.turn;
    }

    public int getWinner()
    {
        return this.winner;
    }

    public bool checkValidMove(int current_slot_id, int destination_slot)
    {
        // jason please complete this 
        // whether a move is valid 
        // does not actually move the piece
        Slots current_Slot = this.slots[current_slot_id];
        Piece current_Piece = current_Slot.piece;
        int current_Value = current_Piece.value;
        if (current_Value == 1){
            return current_Slot.adjcents.Contains(destination_slot);
        } else if (current_Value == 2){
            if (current_slot_id == destination_slot){
                return false;
            }
            foreach (int value in current_Slot.adjcents){
                if (this.slots[value].adjcents.Contains(destination_slot)){
                    return true;
                }
            }
            return false;
        } else if (current_Value == 3){
            if (current_Slot.adjcents.Contains(destination_slot)){
                return false;
            }
            foreach (int value in current_Slot.adjcents){
                foreach (int value1 in this.slots[value].adjcents){
                    if (this.slots[value1].adjcents.Contains(destination_slot)){
                        return true;
                    }
                }
            }
            return false;
        } else if (current_Value == 4){
            list<int> first_Layer = current_Slot.adjcents;
            list<int> second_Layer;
            list<int> third_Layer;
            list<int> fourth_Layer;
            foreach (int value in first_Layer){
                second_Layer = second_Layer.Concat(this.slots[value].adjcents).ToList();
            }
            second_Layer.Remove(current_slot_id);
            foreach (int value in second_Layer){
                third_Layer = third_Layer.Concat(this.slots[value].adjcents).ToList();
            }
            third_Layer = third_Layer.Except(second_Layer);
            foreach (int value in third_Layer){
                fourth_Layer = fourth_Layer.Concat(this.slots[value].adjcents).ToList();
            }
            fourth_Layer = fourth_Layer.Except(third_Layer);  
        }

        return false;
        
    }

    public bool move(int current_slot_id, int destination_slot)
    {
        // check and move valid and move the piece 
        if (!checkValidMove(current_slot_id, destination_slot))
        {
            return false;
        }
        this.slots[destination_slot].piece = this.slots[current_slot_id].piece;
        this.slots[destination_slot].havePiece = true;
        this.slots[current_slot_id].piece.slot = destination_slot;
        this.slots[current_slot_id].havePiece = false;
        this.slots[current_slot_id].piece = null;
        passTurn();
        return true;
    }
        

}