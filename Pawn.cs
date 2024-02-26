using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Pawn : Piece
    {
        private int Direction = 1;
        public bool Passantable;
        public Pawn(string colour)
        {
            Value = 1;
            Name = "Pawn";
            Colour = colour;
            if(Colour == "White")
            {
                Direction = 1;
            } else
            {
                Direction = -1;
            }
            HasMoved = false;
        }

        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            TilesInVision = new List<Move>();
            // EN PASSANT RIGHT
            Move mv = new Move();
            mv.movedPiece = this;

            mv.Row = this.Row + (1 * Direction);
            mv.Column = this.Col + 1;

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, this.Row].TilePiece != null)
                {
                    if(brd.Tiles[mv.Column, this.Row].TilePiece.Colour != this.Colour && brd.Tiles[mv.Column, this.Row].TilePiece.Name == "Pawn")
                    {
                        //MessageBox.Show("passantable right");
                        //passantpiece = (Pawn)brd.Tiles[mv.Column, this.Row].TilePiece;
                        //if (brd.Game.GetLastMove() != null && brd.Game.GetLastMove().movedPiece == passantpiece)
                        //{
                        //    mv.Type = "En Passant";
                        //    mv.capturedPiece = brd.Tiles[mv.Column, this.Row].TilePiece;
                        //    movelist.Add(mv);
                        //}

                        if (brd.Tiles[mv.Column, this.Row].TilePiece.HasMoved == false)
                        {
                            mv.Type = "En Passant Capture";
                            mv.capturedPiece = brd.Tiles[mv.Column, this.Row].TilePiece;
                            movelist.Add(mv);
                        }
                    }
                    
                }
            }
            // EN PASSANT LEFT
            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            mv.Column = this.Col - 1;

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, this.Row].TilePiece != null && brd.Tiles[mv.Column, this.Row].TilePiece.Colour != this.Colour)
                {
                    if (brd.Tiles[mv.Column, this.Row].TilePiece.Name == "Pawn")
                    {
                        //MessageBox.Show("passantable left");
                        //passantpiece = (Pawn)brd.Tiles[mv.Column, this.Row].TilePiece;
                        //if (brd.Game.GetLastMove() != null && brd.Game.GetLastMove().movedPiece == passantpiece)
                        //{
                        //    mv.Type = "En Passant";
                        //    mv.capturedPiece = brd.Tiles[mv.Column, this.Row].TilePiece;
                        //    movelist.Add(mv);
                        //}

                        if (brd.Tiles[mv.Column, this.Row].TilePiece.HasMoved == false)
                        {
                            mv.Type = "En Passant Capture";
                            mv.capturedPiece = brd.Tiles[mv.Column, this.Row].TilePiece;
                            movelist.Add(mv);
                        }
                    }

                }
            }
            // moving 1 ahead

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            //MessageBox.Show($"Colour is {Colour} and Direction is {Direction}");
            mv.Column = this.Col;

            if (checkBoundary(mv) == true && (mv.Row != 7 || mv.Row != 0)) // if the move is within the boundaries of the board
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            // moving forward by 2

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (2 * Direction);
            mv.Column = this.Col;

            if (brd.Tiles[this.Col, this.Row + (1 * Direction)].TilePiece == null)
            {
                // if the piece has not moved from its starting position
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null && (this.Row == 1 || this.Row == 6))
                {
                    //MessageBox.Show("Double move possible");
                    mv.Type = "Double Move";
                    movelist.Add(mv);
                    TilesInVision.Add(mv);
                }
            }
            // capturing right

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            mv.Column = this.Col + 1;

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        mv.Type = "Capture";
                        movelist.Add(mv);
                        TilesInVision.Add(mv);
                    }
                }
                
            }
            // capturing left

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            mv.Column = this.Col - 1;

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        mv.Type = "Capture";
                        movelist.Add(mv);
                        TilesInVision.Add(mv);
                    }
                }

            }

            return movelist;
        }

        
    }
}
