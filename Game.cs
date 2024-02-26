using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Game
    {
        private List<Move> Moves;
        private string PGN;
        public bool WhiteMove;
        private bool Check;
        public bool CheckMate;
        private int NumberOfMoves;
        public Player PlayerWhite;
        public Player PlayerBlack;
        enum Outcome
        {
            BlackWin = 0,
            Draw = 1,
            WhiteWin = 2
        }
        public Game()
        {
            WhiteMove = true;
            PlayerWhite = new Player()
            {
                Colour = "White"
            };
            PlayerBlack = new Player()
            {
                Colour = "Black"
            };
            Moves = new List<Move>();
        }
        public void AddMove(Move mv)
        {
            Moves.Add(mv);
        }

        public bool IsInCheck()
        {
            return Check;
        }

        public void SetCheck(bool check)
        {
            Check = check;
        }

        
    }
}
