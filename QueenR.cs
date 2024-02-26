using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class QueenR : Piece
    {
        protected List<Move> movelist;

        public QueenR()
        {
            Value = 9;
            Name = "Queen";
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
            upRight(brd, 1);
            upLeft(brd, 1);
            downRight(brd, 1);
            downLeft(brd, 1);
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

        public void upRight(Board brd, int dist)
        {
            mv = new Move()
            {
                Row = this.Row + dist,
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
                    upRight(brd, dist + 1);
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
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
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
            mv = new Move()
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
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
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
            mv = new Move()
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
