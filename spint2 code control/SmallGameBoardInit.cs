namespace FinalProject;

public class SmallGameBoardInit
{
    private int[,] adjency;

    public SmallGameBoardInit()
    {
        this.adjency = new int[,]
        {
            {2, 7, -1}, // 1
            {1, 3, -1},
            {2, 4, 9},
            {3, 5, -1},
            {4, 11, -1},
            {7, 13, -1}, // 6
            {6, 8, 1},
            {8, 10, 3},
            {9, 11, 17},
            {12, 10, 5},
            {19, 11, -1},
            {6, 14, -1}, // 13
            {13, 15, 20},
            {14, 16, 8},
            {15, 17, 5},
            {16, 18, 10},
            {19, 19, 24},
            {14, 21, -1}, // 20
            {20, 22, -1},
            {21, 23, -1},
            {22, 24, -1},
            {25, 18, -1},            
        };
    }

    public void loadAdjcency(Slots[] slots)
    {
        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                slots[i].adjcents[j] = this.adjency[i,j];
            }
            
        }
    }
}