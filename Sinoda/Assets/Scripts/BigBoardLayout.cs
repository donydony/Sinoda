using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Board/Slots/Layout")]

public class BigBoardLayout : ScriptableObject
{
    [Serializable]
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
    
    public int GetPieceSlotAtIndex(int index)
    {
        return Pieces[index].slot;
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
