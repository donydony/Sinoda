using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Board/Slots/Layout")]

public class BigBoardLayout : ScriptableObject
{   [Serializable]
    public class Piece1
    {
        // Start is called before the first frame update

        public int slot;
        public int value;
        public int owner;
    }
    [SerializeField] private Piece1[] Pieces;

    public int GetPiecesCount()
    {
        return Pieces.Length;
    }
    private double[] xs = new double[] {-18.13423, -21.79423, -18.13423, -21.79423, -18.13423, -21.79423, -18.13423,
        -8.894233, -12.48423, -8.894233, -12.48423, -8.894233, -12.48423, -8.894233, -12.48423, -8.894233,
        0.6657668, -3.094233, 0.6657668, -3.094233, 0.6657668, -3.094233, 0.6657668, -3.094233, 0.6657668, -3.094233, 0.6657668,
        6.105767, 9.625768, 6.105767, 9.625768, 6.105767, 9.625768, 6.105767, 9.625768, 6.105767, 9.625768,6.105767,
        15.70577, 18.90577, 15.70577, 18.90577, 15.70577, 18.90577, 15.70577, 18.90577, 15.70577, 18.90577,
        25.40577, 28.33577, 25.40577, 28.33577, 25.40577, 28.33577, 25.40577
    };
        
        
    private double[] ys = new double[]{-10.62995, -6.029951, -2.129951, 2.370049, 6.670049, 11.07005, 15.32005,
        -14.82995, -10.32995, -6.129951, -2.029951, 2.370049, 6.770049, 11.11005, 15.27005, 19.51005,
        -19.00995, -14.82995, -10.42995, -5.959951, -2.029951, 2.570049, 6.670049, 10.87005, 15.17005, 19.17005, 23.57005,
        -19.00995, -14.82995, -10.42995, -5.959951, -2.029951, 2.570049, 6.670049, 10.87005, 15.17005, 19.17005, 23.57005,
        -14.82995, -10.32995, -6.129951, -2.029951, 2.370049, 6.770049, 11.11005, 15.27005, 19.51005,
        -10.62995, -6.029951, -2.129951, 2.370049, 6.670049, 11.07005, 15.32005};

    public Vector2 GetpieceCoordsAtIndex(int index)
    {
        return new Vector3((float)xs[Pieces[index].slot],0, (float)ys[Pieces[index].slot]);
    }
    public int GetPieceOwnerteamAtIndex(int index)
    {
        return Pieces[index].owner;
    }
    public int GetPieceValueteamAtIndex(int index)
    {
        return Pieces[index].value;
    }


}
