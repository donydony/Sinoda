using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    public Text Red;

    public Text Blue;

    public Text Green;
    public Text Yellow;
    public int yellowScore;

    public int redScore = 0;

    public int blueScore = 0;

    public int greenScore = 0;

    public void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Red.text = "RED SCOREs: " + redScore.ToString();
        Blue.text = "BLUE SCORE: " + blueScore.ToString();
        Green.text = "GREEN SCORE: " + greenScore.ToString();
        Yellow.text = "YELLOW SCORE: " + yellowScore.ToString();
    }

    public void AddRed(int n)
    {
        redScore += n;
        Red.text = "RED SCORE: " + redScore.ToString();
    }

    public void AddBlue(int n)
    {
        blueScore += n;
        Blue.text = "BLUE SCORE: " + blueScore.ToString();
    }

    public void AddGreen(int n)
    {
        greenScore += n;
        Green.text = "GREEN SCORE: " + greenScore.ToString();
    }
    
    public void AddYellow(int n)
    {
        yellowScore += n;
        Yellow.text = "YELLOW SCORE: " + yellowScore.ToString();
    }
    
}
