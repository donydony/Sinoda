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
    

}