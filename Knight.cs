using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Knight : Piece
    {
        // horsey move in L shape :^)

        public Knight()
        {
            Value = 3;
            Name = "Knight";

        }
        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            TilesInVision = new List<Move>();
            Move mv = new Move();
            mv.movedPiece = this;
            // up 2 right 1
            mv.Row =   this.Row + 2;
            mv.Column = this.Col + 1;

            if(checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                } else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // up 2 left 1
            mv.Row = this.Row + 2;
            mv.Column = this.Col - 1;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // up 1 left 2
            mv.Row = this.Row + 1;
            mv.Column = this.Col - 2;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // down 1 left 2
            mv.Row = this.Row - 1;
            mv.Column = this.Col - 2;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // down 2 left 1
            mv.Row = this.Row - 2;
            mv.Column = this.Col - 1;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // down 2 right 1
            mv.Row = this.Row - 2;
            mv.Column = this.Col + 1;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // down 1 right 2
            mv.Row = this.Row - 1;
            mv.Column = this.Col + 2;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            mv = new Move();
            // up 1 right 2
            mv.Row = this.Row + 1;
            mv.Column = this.Col + 2;
            mv.movedPiece = this;
            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null) // if no piece on square then move
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour) // if piece on square is opposite colour then capture
                {
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    mv.Type = "Capture";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            return movelist;
        }
    }
}
