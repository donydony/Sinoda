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

    public bool checkValidMove(int current_piece_id, int destination_slot)
    {
        // jason please complete this 
        // whether a move is valid 
        // does not actually move the piece 
        return false;
        
    }

    public bool move(int current_piece_id, int destination_slot)
    {
        // check and move valid and move the piece 
        if (!checkValidMove(current_piece_id, destination_slot))
        {
            return false;
        }



        passTurn();
        return true;
    }
        

}