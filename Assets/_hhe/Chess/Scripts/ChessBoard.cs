/*
 * Chess
 * 
 * https://www.chess.com/learn-how-to-play-chess
 * 
 * 
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{

    public enum GameType
    {
        chess = 0
    }
    public GameType gameType = GameType.chess;

    public enum CurrentTeam
    {
        white,
        black
    }
    public CurrentTeam currentTeam = CurrentTeam.white;


    public enum CurrentGamePieceType
    {
        pawn,
        rook,
        knight,
        bishop,
        queen,
        king
    }



    //[Title=Board]

    int MAX_X = 8;
    int MAX_Y = 1;
    int MAX_Z = 8;



    //    int[,] a = new int[3, 4] {
    //   {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
    //   {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
    //   {8, 9, 10, 11}   /*  initializers for row indexed by 2 */
    //   };

    int[,,] boardCurrentTeam;
    int[,,] boardCurrentGamePieceType;


    void Start()
    {
        boardCurrentTeam = new int[MAX_X, MAX_Y, MAX_Z];
        boardCurrentGamePieceType = new int[MAX_X, MAX_Y, MAX_Z];
    }

    void Initialize_Board(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.chess:
                Initialize_Chess();
                break;
            default:
                break;
        }

        void Initialize_Chess()
        {
            //white
            for (int x = 0; x < MAX_X; x++)
            {
                boardCurrentTeam[x, 0, 0] = (int)CurrentTeam.white;
            }
            for (int x = 0; x < MAX_X; x++)
            {
                boardCurrentTeam[x, 0, 1] = (int)CurrentTeam.white;
                boardCurrentGamePieceType[x, 0, 1] = (int)CurrentGamePieceType.pawn;
            }
        }
    }


    void Update()
    {
        
    }
}
