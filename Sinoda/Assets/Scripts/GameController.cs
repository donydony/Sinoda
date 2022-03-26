using System.Collections;
using System.Collections.Generic;
using InnerDriveStudios.DiceCreator;
using UnityEngine;
/*
 * Main game Controller
 * Start game, End game
 * 
 */
[RequireComponent(typeof(PieceGenerater))]
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BigBoardLayout layout;
    [SerializeField] private Board board;
    [SerializeField] private int Player_number;
    private List<Player> Players;
    public int ActivePlayer;
    private PieceGenerater pieceCreator;
    
    private void Awake()
    {
        pieceCreator = GetComponent<PieceGenerater>();
        
    }
    private void Start()
    {
        CreatePlayer();
        Startthegame();
        
        ActivePlayer = 0;
        GenerateAllPossibleMoves(Players[ActivePlayer]);
        this.board.SetController(this);
    }

    // Update is called once per frame
    private void Startthegame()
    {
        for (int i = 0; i < layout.GetPiecesCount(); i++)
        {
            
            int owner = layout.GetPieceOwnerteamAtIndex(i);
            int value = layout.GetPieceValueteamAtIndex(i);
            int slot = layout.GetPieceSlotAtIndex(i);
            int turn = board.IfTurnAtSlot(slot);
            Vector3 squareCoords = board.GetPositionAtSlot(slot);
            Piece newp = pieceCreator.CreatePiece(owner).GetComponent<Piece>();
            newp.SetData(squareCoords, owner, value, slot, turn,i,board);
            this.board.AddPieceToBoard(slot, newp);
            //===========================================================================
            Players[owner].addPiece(newp);
        }
    }

    private void CreatePlayer()
    {   //If u need add AI, add it here
        Players = new List<Player>();
        for (int i=0; i<Player_number;i++)
        {
            Players.Add(new Player(i, this.board));
        }
    }

    private void GenerateAllPossibleMoves(Player p)
    {
        p.AllPossibleMoves();
    }

    public void SwitchTurn()
    {
        
        
        if (CheckStats())
        {
            win(); 
        }
        SwitchToAvailablePlayer();
        GenerateAllPossibleMoves(Players[ActivePlayer]);
    }
    public bool IfTurnTrue(int i)
    {
        return ActivePlayer == i;
    }

    public void capturepiece(Piece p)
    {
        Players[p.owner].removePiece(p);
        Players[ActivePlayer].Addpoint(p.value);
        Destroy(p.gameObject);
    }

    public bool CheckStats()
    {
        int count = 0;
        int countone = 0;
        for (int i = 0; i < Player_number; i++)
        {
            if (Players[i].zeroleft())
            {
                count++;
            }
            if (Players[i].oneleft())
            {
                countone++;
            }
        }
        if(count == Player_number - 1)//if one player left
        {
            return true;
        }
        if(count == Player_number -2 && countone == 2)// if last two both one piece left
        {
            return true;
        }
        return false;
        
    }

    private void win()
    {   //What happen when winning?
        // TODO
        board.win();
        int maxpiont = 0;
        int player = -1;
        for (int i = 0; i < Player_number; i++)
        {
            if (Players[i].score > maxpiont)
            {
                maxpiont = Players[i].score;
                player = i;
            }
        }
        Debug.Log("player:" + player + "win");
    }
    private void SwitchToAvailablePlayer()
    {
        do
        {
            ActivePlayer++;
            if (ActivePlayer == Player_number)
            {
                ActivePlayer = 0;
            }
        } while (Players[ActivePlayer].zeroleft());
    }
}
