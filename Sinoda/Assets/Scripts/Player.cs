using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
