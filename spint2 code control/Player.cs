namespace FinalProject;

public class Player
{
    public int player_id;
    public CapturePlate plate;
    public int score;

    public Player(int id)
    {
        this.player_id = id;
        plate = new CapturePlate(id);
        this.score = 0;
    }
    
    public bool capture()
    {
        this.score = this.plate.getScore();
        return false;
    }
    
    public bool moveTo()
    {
        // must do some sort of path find    
        // if we are just moving we can return
        // if we are capturing we are calling capture 
        return false;
    }
    
}