using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private int[] BotPlayerMapping;
    [SerializeField] private bool GameDone = false;
    // if player n is a bot player BotPlayerMapping[n] = 1;

    private void Awake()
    {
        pieceCreator = GetComponent<PieceGenerater>();
        BotPlayerMapping = new int [Player_number];
        for (int i = 0; i < Player_number; i++)
        {
            BotPlayerMapping[i] = 0;
            // initially set all players to be not bot 
        }
        // if you need to set a player to bot 
        // just set it here 
        //BotPlayerMapping[1] = 1;
    }

    public bool IsBot(int playern)
    {
        return BotPlayerMapping[playern] == 1;
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
        BotManager();
    }
    public bool IfTurnTrue(int i)
    {
        return ActivePlayer == i;
    }

    public void capturepiece(Piece p)
    {
        Players[p.owner].removePiece(p);
        Players[ActivePlayer].Addpoint(p.value);
        Debug.Log("Currently @ Player: "+ActivePlayer);
        if (ActivePlayer == 0)
        {
            ScoreController.instance.AddRed(p.value);
            Debug.Log("Adding Points: "+p.value+" to Player Red");
            Debug.Log("Current Score is "+Players[ActivePlayer].score);
        }
        else if (ActivePlayer == 1)
        {
            ScoreController.instance.AddBlue(p.value);
            Debug.Log("Adding Points: "+p.value+" to Player Blue");
            Debug.Log("Current Score is "+Players[ActivePlayer].score);
        }
        else if (ActivePlayer == 2)
        {
            ScoreController.instance.AddGreen(p.value);
            Debug.Log("Adding Points: "+p.value+" to Player Green");
            Debug.Log("Current Score is "+Players[ActivePlayer].score);
        }
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
        GameDone = true;
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

    private int[] GetPlayerPieceLocation(int playern)
    {
        int playern_piece_count = Players[playern].Pieces.Count;
        int[] location = new int [playern_piece_count];
        for( int i = 0;i<playern_piece_count;i++)
        {
            location[i] = Players[playern].Pieces[i].slot;
        }

        return location;
        
    }
    
    private void BotManager()
    {
        Debug.Log(IsBot(ActivePlayer));
        if (CheckStats())
        {
            win(); 
        }

        if (GameDone)
        {
            return;
        }
        if (IsBot(ActivePlayer))
        {
            // get available moves 
            GenerateAllPossibleMoves(Players[ActivePlayer]);
            // check for capture 
            // for every piece the current player controls 
            foreach (Piece p in Players[ActivePlayer].Pieces)
            {   
                // look for capture for every other player 
                foreach (Player pn in Players)
                {
                    if (pn.player_id != ActivePlayer)
                    {
                        int[] location = GetPlayerPieceLocation(pn.player_id);
                        // look for every available move 
                        foreach (int m in p.availablemoves)
                        {
                            // if we can capture we capture 
                            if (location.Contains(m))
                            {
                                Debug.Log("1");
                                board.SelectPiece(p);
                                board.Moving(m);
                                // p.moveto(m);
                                if (CheckStats())
                                {
                                    win(); 
                                }
                                return;
                            }
                        }
                    }
                }

            }
            
            // no capture available 
            // roll up or randomly move a piece 

            int choice = Random.Range(-3, 3);
            if (choice > 0)
            {
                Debug.Log("2");
                // roll up a random piece 
                int rolling_piece = Random.Range(0, Players[ActivePlayer].Pieces.Count);
                if (Players[ActivePlayer].Pieces[rolling_piece].value < 4)
                {
                    Players[ActivePlayer].Pieces[rolling_piece].rollup();
                    SwitchTurn();
                    return;
                }
                else
                {
                    Players[ActivePlayer].Pieces[rolling_piece].rolldown();
                    SwitchTurn();
                    return;
                }
            }
            else
            {
                // move a random piece 
                Debug.Log("3");
                while (true)
                {
                    int moving_piece = Random.Range(0, Players[ActivePlayer].Pieces.Count);
                    foreach (int m in Players[ActivePlayer].Pieces[moving_piece].availablemoves)
                    {
                        int[] locations = GetPlayerPieceLocation(ActivePlayer);
                        if (!locations.Contains(m))
                        {
                            Players[ActivePlayer].Pieces[moving_piece].moveto(m);
                            SwitchTurn();
                            return;
                        }
                    }
                }
                
                
                
            }
        }
        
        Debug.Log("end");
        

    }
}
