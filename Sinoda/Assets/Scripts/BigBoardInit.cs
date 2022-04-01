using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoardInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private int[,] adjency;
    public BigBoardInit()
    {
        this.adjency = new int[,] 
            {   { -1, 2, 9 }, // 1
                { 3, 1, -1 }, 
                { 2, 4, 11 }, 
                { 3, 5, -1 }, 
                { 4, 6, 13 },
                { 7, 5, -1 },
                { 6, 15, -1 },
                { 18, 9, -1 }, // 8
                { 8, 10, 1 },
                { 9, 20, 11 },
                { 3, 10, 12 },
                { 13, 11, 22 },
                { 14, 5, 12 },
                { 13, 15, 24 },
                { 14, 16, 7 },
                { 26, 15, -1 },
                { 18, 28, -1 }, // 17
                { 19, 8, 17 },
                { 18, 20, 30 },
                { 21, 19, 10 },
                { 32, 20, 22 },
                { 23, 21, 12 },
                { 34, 22, 24 },
                { 23, 25, 14 },
                { 24, 26, 36 },
                { 27, 25, 16 },
                { 26, 38, -1 },
                { 17, 29, -1 }, // 28
                { 28, 30, 39 },
                { 31, 29, 19 },
                { 30, 32, 41 },
                { 31, 33, 21 },
                { 32, 34, 43 },
                { 33, 35, 23 },
                { 34, 36, 45 },
                { 37, 35, 25 },
                { 36, 38, 47 },
                { 37, 27, -1 },
                { 29, 40, -1 }, // 39
                { 39, 41, 48 },
                { 40, 31, 42 },
                { 41, 43, 50 },
                { 33, 42, 44 },
                { 43, 45, 52 },
                { 35, 44, 46 },
                { 45, 47, 54 },
                { 37, 46, -1 },
                { 40, 49, -1 }, // 48
                { 48, 50, -1 },
                { 49, 51, -1 },
                { 52, 50, -1 },
                { 53, 51, -1 },
                { 52, 54, -1 },
                { 46, 53, -1 }
            };
    }

    public void loadAdjcency(Slots[] slots)
    {
        for (int i = 0; i < 54; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                slots[i].adjcents[j] = this.adjency[i,j];
            }
            
        }
    }
}
