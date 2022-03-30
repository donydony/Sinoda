using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int player_id;
    public int score;
    public Board board;
    public List<Piece> Pieces;
    public Player(int id, Board b)
    {
        this.player_id = id;
        this.board = b;
        this.score = 0;
        this.Pieces = new List<Piece>();
    }

    public void addPiece(Piece p)
    {
        if (!Pieces.Contains(p))
        {
            Pieces.Add(p);
        }
        
    }

    public void removePiece(Piece p)
    {
        if (Pieces.Contains(p))
        {
            Pieces.Remove(p);
        }

    }
    public void AllPossibleMoves()
    {
        foreach(var Piece in Pieces)
        {
            Piece.SelectPossibleMoves();
        }
    }

    public void Addpoint(int i)
    {
        score += i;
    }

    public bool oneleft()
    {
        return Pieces.Count == 1;
    }
    public bool zeroleft()
    {
        return Pieces.Count == 0;
    }

}
