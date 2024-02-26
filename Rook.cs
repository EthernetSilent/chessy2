using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Rook : Piece
    {
        public Rook()
        {
            Value = 5;
            Name = "Rook";
        }
        //getmoves will be a linklist
        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            Move mv;
            int increment;

            increment = 1;
            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col + increment; // right
            mv.Row = this.Row;
            while (checkBoundary(mv) == true)
            {

                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);

                    increment++;
                    mv = new Move();
                    mv.movedPiece = this;
                    mv.Column = this.Col + increment;
                    mv.Row = this.Row;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour == this.Colour)
                {
                    break;
                }
            }

            increment = 1;
            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col - increment; // left
            mv.Row = this.Row;
            while (checkBoundary(mv) == true)
            {

                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);

                    increment++;
                    mv = new Move();
                    mv.movedPiece = this;
                    mv.Column = this.Col - increment;
                    mv.Row = this.Row;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour == this.Colour)
                {
                    break;
                }
            }


            increment = 1;
            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col;
            mv.Row = this.Row - increment; // down
            while (checkBoundary(mv) == true)
            {

                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);

                    increment++;
                    mv = new Move();
                    mv.movedPiece = this;
                    mv.Column = this.Col;
                    mv.Row = this.Row - increment;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour == this.Colour)
                {
                    break;
                }
            }


            increment = 1;
            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col;
            mv.Row = this.Row + increment; // up
            while (checkBoundary(mv) == true)
            {

                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);

                    increment++;
                    mv = new Move();
                    mv.movedPiece = this;
                    mv.Column = this.Col;
                    mv.Row = this.Row + increment;
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour == this.Colour)
                {
                    break;
                }
            }


            return movelist;
        }
    }
}
