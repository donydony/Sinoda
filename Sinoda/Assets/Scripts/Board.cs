using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HitBoxGenerater))]
public class Board: MonoBehaviour
{
    [SerializeField] static private double[] ca = new double[] { -42.6, -24.7, -6.6, 12.6, 29.9, 49.7 };
    [SerializeField] static private double[] cb = new double[] { -49.6, -31.9, -12.7, 5.7, 24.1, 43.6 };
    [SerializeField] static private double[] r = new double[] { 42.1, 33.6, 24.7, 16.8, 8.3, 0, -8.3, -16.8, -24.7, -33.6, -42.1 };
    [SerializeField] static private double y = 3;
    [SerializeField] const int num_slots = 54;
    static private double[] xs = new double[] {
        ca[0], cb[0], ca[0], cb[0], ca[0], cb[0], ca[0],
        ca[1], cb[1], ca[1], cb[1], ca[1], cb[1], ca[1],cb[1],ca[1],
        ca[2], cb[2], ca[2], cb[2], ca[2], cb[2], ca[2],cb[2],ca[2],cb[2],ca[2],
        cb[3], ca[3], cb[3], ca[3], cb[3], ca[3],cb[3],ca[3],cb[3],ca[3],cb[3],
        cb[4], ca[4], cb[4], ca[4], cb[4], ca[4],cb[4],ca[4],cb[4],
        cb[5], ca[5], cb[5], ca[5], cb[5], ca[5],cb[5],
    };
    static private int[] ifturn = new int[] {
        0,1,0,1,0,1,0,
        0,1,0,1,0,1,0,1,0,
        0,1,0,1,0,1,0,1,0,1,0,
        1,0,1,0,1,0,1,0,1,0,1,
        1,0,1,0,1,0,1,0,1,
        1,0,1,0,1,0,1
    };

    static private double[] ys = new double[]{
                      r[8], r[7], r[6], r[5], r[4], r[3], r[2],
                r[9], r[8], r[7], r[6], r[5], r[4], r[3], r[2], r[1],
         r[10], r[9], r[8], r[7], r[6], r[5], r[4], r[3], r[2], r[1], r[0],
         r[10], r[9], r[8], r[7], r[6], r[5], r[4], r[3], r[2], r[1], r[0],
                r[9], r[8], r[7], r[6], r[5], r[4], r[3], r[2], r[1],
                      r[8], r[7], r[6], r[5], r[4], r[3], r[2],
     };
    static private int[,] adjacency = new int[,]{   { -1, 2, 9 }, // 1
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
                { 49, 51, 42 },
                { 52, 50, -1 },
                { 53, 51, 44 },
                { 52, 54, -1 },
                { 46, 53, -1 }
            };
//==================================================================================================
private Piece[] Grid;
    private Piece SelectedPiece;
    private GameController controller;
    private HitBoxGenerater hitboxcreator;
    private bool winstats;
    private void Awake()
    {
        CreateBoard();
        winstats = false;
    }
    public void SetController(GameController c)
    {
        hitboxcreator = GetComponent<HitBoxGenerater>();
        this.controller = c;
    }
    private void CreateBoard()
    {
        Grid = new Piece[num_slots];
    }
    public void AddPieceToBoard(int slot, Piece p)
    {
       Grid[slot-1] = p;
    }
    public void HandlePiece(Piece p)
    {
        if (!winstats)
        {
            if (SelectedPiece)
            {
                if (SelectedPiece.slot == p.slot)
                {
                    DeselectPiece();
                }
                else
                {
                    if (controller.IfTurnTrue(p.owner))
                    {
                        DeselectPiece();
                        SelectPiece(p);
                    }

                }

            }
            else
            {
                if (controller.IfTurnTrue(p.owner))
                {
                    SelectPiece(p);
                }
            }
        }
    }
    public void HandleHitBox(HitBox h)
    {
        if (SelectedPiece)
        {
            Moving(h.slot);
        }
    }

    public void SelectPiece(Piece p)
    {
        SelectedPiece = p;
        p.Selected(true);
        GenerateHitBox();
    }

    public void DeselectPiece()
    {
        SelectedPiece.Selected(false);
        SelectedPiece = null;
        hitboxcreator.close();
    }
    public void GenerateHitBox()
    {
        hitboxcreator.close();
        foreach (var i in SelectedPiece.availablemoves)
        {
            HitBox b = hitboxcreator.show().GetComponent<HitBox>();
            b.SetData(GetPositionAtSlot(i), i, IfTurnAtSlot(i), this);
        }
    }
    public void SwitchTurn()
    {
        controller.SwitchTurn();
    }

    public Vector3 GetPositionAtSlot(int slot)
    {
        
        return new Vector3((float)xs[slot - 1], (float)y, (float)ys[slot - 1]);
    }

    public int IfTurnAtSlot(int slot)
    {
        return ifturn[slot - 1];
    }
    public Piece GetPieceBySlot(int slot)
    {
        return Grid[slot-1];
    }

    public void Moving(int slot)
    {
        if (hasenemypiece(slot,SelectedPiece.owner))
        {
            CapturedPiece(slot);
        }
        Grid[slot-1] = SelectedPiece;
        Grid[SelectedPiece.slot-1] = null;
        SelectedPiece.moveto(slot);
        SelectedPiece = null;
        hitboxcreator.close();
        SwitchTurn();
    }

    public bool hasenemypiece(int slot, int o)
    {
        if (haspiece(slot))
        {
            if(Grid[slot-1].owner != o)
            {
                return true;
            }
        }
        return false;
            
    }
    public bool hasfriendpiece(int slot, int o)
    {
        if (haspiece(slot))
        {
            if (Grid[slot - 1].owner == o)
            {
                return true;
            }
        }
        return false;
    }
    public bool haspiece(int slot)
    {
        if (Grid[slot - 1] == null)
        {
            return false;
        }
        return true;
    }
    public void CapturedPiece(int slot)
    {
        Piece p = Grid[slot - 1];
        
        controller.capturepiece(p);
        
    }
    public int[] getadjacency(int slot)
    {
        int[] a = new int[3];
        for(int i = 0; i < 3; i++)
        {
            a[i] = adjacency[slot-1, i];
        }
        return a;
    }

    public void rollup()
    {
        if (SelectedPiece)
        {
            if (SelectedPiece.rollup())
            {
                DeselectPiece();
                SwitchTurn();
            }
        }
    }

    public void rolldown()
    {
        if (SelectedPiece)
        {
            if(SelectedPiece.rolldown()){
                DeselectPiece();
                SwitchTurn();
            }
        }
        
    }

    public void win()
    {
        this.winstats = true;
    }












}
