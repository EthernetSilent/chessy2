using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Piece
    {
        protected int Value;
        private bool colourbool = true;
        public Move Position;
        public int Row, Col;
        public string Name = "";
        public bool HasMoved;
        public List<Move> TilesInVision;
        //public Tile position;
        //protected enum PieceType
        //{
        //    Pawn = 1,
        //    Knight = 3,
        //    Bishop = 4,
        //    Rook = 5,
        //    Queen = 9,
        //    King = 10
        //}

        
        protected bool checkBoundary(Move mv)
        {
            if (mv.Row < 0 || mv.Row > 7 || mv.Column < 0 || mv.Column > 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Colour
        {
            get
            {
                if (colourbool)
                {
                    return "White";
                }
                else
                {
                    return "Black";
                }
            }
            set
            {
                if (value.ToLower() == "white")
                {
                    colourbool = true;
                }
                else
                {
                    colourbool = false;
                }
            }
        }
        public void MovePiece(int col, int row)
        {
            this.Col = col;
            this.Row = row;
        }
        public virtual List<Move> GetMoves(Board brd)
        {
            return null;
        }

        
    }
}
