using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class RookR : Piece
    {
        protected List<Move> movelist;
        public RookR()
        {
            Value = 5;
            Name = "Rook";
            HasMoved = false;
        }
        private Move mv;
        public override List<Move> GetMoves(Board brd)
        {
            movelist = new List<Move>();
            TilesInVision = new List<Move>();
            up(brd, 1);
            down(brd, 1);
            left(brd, 1);
            right(brd, 1);
            return movelist;
        }
        public void up(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row + dist,
                Column = this.Col,
                movedPiece = this
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                    dist++;
                    up(brd, dist);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }

        public void down(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row - dist,
                Column = this.Col,
                movedPiece = this
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                    dist++;
                    down(brd, dist);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }

        public void left(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row,
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
                    dist++;
                    left(brd, dist);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
        }

        public void right(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row,
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
                    dist++;
                    right(brd, dist);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
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
