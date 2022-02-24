namespace FinalProject;

public class Board
{
    private int player_count;
    private Slots[] slots = new Slots[54];
    private Player[] _players;
    private int turn;
    
    
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
        this._players = new Player[playerCount];
        if (!this.init())
        {
           // fail for some reason 
        }
        
    }

    public void passTurn()
    {
        turn = (turn + 1) % this.player_count;
        
    }
        

}