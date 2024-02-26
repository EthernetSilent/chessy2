using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class BishopR : Piece
    {
        // recursively scan moves

        

        protected List<Move> movelist;

        public BishopR()
        {
            Value = 3;
            Name = "Bishop";
        }
        private Move mv;
        public override List<Move> GetMoves(Board brd)
        {
            movelist = new List<Move>();
            TilesInVision = new List<Move>();
            upRight(brd, 1);
            upLeft(brd, 1);
            downRight(brd, 1);
            downLeft(brd, 1);
            return movelist;
        }
        public void upRight(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row + dist,
                Column = this.Col + dist,
                movedPiece = this
            };

            if(checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column,mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                    upRight(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }

        public void upLeft(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row + dist,
                Column = this.Col - dist,
                movedPiece = this
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                    upLeft(brd, dist + 1); // callback because you might be able to move forward
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }
        public void downRight(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row - dist,
                Column = this.Col + dist,
                movedPiece = this
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                    downRight(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }

        public void downLeft(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row - dist,
                Column = this.Col - dist,
                movedPiece = this
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                    downLeft(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }
    }
}
