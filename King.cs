using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class King : Piece
    {
        public King()
        {
            Name = "King";
            Value = 999;
            HasMoved = false;
        }

        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            TilesInVision = new List<Move>();
            Move mv;

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col + 1;
            mv.Row = this.Row + 1;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }


            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col + 1;
            mv.Row = this.Row;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col + 1;
            mv.Row = this.Row - 1;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col;
            mv.Row = this.Row - 1;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col - 1;
            mv.Row = this.Row - 1;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col - 1;
            mv.Row = this.Row;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col - 1;
            mv.Row = this.Row + 1;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col;
            mv.Row = this.Row + 1;

            if (checkBoundary(mv) == true)
            {
                if (!brd.IsThisTileInVision(mv))
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece != null && brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.Type = "Capture";
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        movelist.Add(mv);
                    }
                    else if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                    {
                        mv.Type = "Move";
                        movelist.Add(mv);
                    }
                }
            }

            // castling long/left/queenside

            mv = new Move();
            Move tempmv;
            mv.movedPiece = this;
            bool TilesClear = true;
            // check the position of the king
            if (this.Col == 4 && ((this.Row == 0 && this.Colour == "White") || (this.Row == 7 && this.Colour == "Black"))) 
            {
                // check the position (and colour) of the rook
                if (brd.Tiles[0, this.Row].TilePiece.Name == "Rook" && brd.Tiles[0, this.Row].TilePiece.Colour == this.Colour)
                {
                    // check if the queenside rook and king have moved
                    if(this.HasMoved == false && this.HasMoved == brd.Tiles[0, this.Row].TilePiece.HasMoved)
                    {
                        // check if each tile is free (does not have a piece on it), does not move through or into check (is in vision of an attacking piece)
                        // ie check if tilepiece is null and if tile is in tilesinvision

                        for (int x = 3; x >= 1; x--)
                        {
                            tempmv = new Move();
                            tempmv.Row = this.Row;
                            tempmv.Column = x;
                            if (this.Colour == "White")
                            {
                                // check row 0, check black tiles in vision

                                if((brd.BlackMovesInVision.Count<Move>() != 0 && brd.BlackMovesInVision.Contains(tempmv)) || brd.Tiles[tempmv.Column, tempmv.Row].TilePiece != null)
                                {
                                    // if one of the tiles is in vision or has a piece on it
                                    TilesClear = false;

                                    //mv.Column = x;
                                    //mv.Row = this.Row;
                                    //mv.movedPiece2 = brd.Tiles[0, this.Row].TilePiece;
                                    //mv.Type = "Long Castle";
                                    //movelist.Add(mv);
                                    //TilesInVision.Add(mv);
                                }
                            } else // if it isnt white, its black
                            {
                                if ((brd.WhiteMovesInVision.Count<Move>() != 0 && brd.WhiteMovesInVision.Contains(tempmv)) || brd.Tiles[tempmv.Column, tempmv.Row].TilePiece != null)
                                {
                                    TilesClear = false;
                                    //mv.Column = x;
                                    //mv.Row = this.Row;
                                    //mv.movedPiece2 = brd.Tiles[0, this.Row].TilePiece;
                                    //mv.Type = "Long Castle";
                                    //movelist.Add(mv);
                                    //TilesInVision.Add(mv);
                                }
                            }
                        }

                        if(TilesClear)
                        {
                            mv.Type = "Long Castle";
                            //mv.Row = this.Row;
                            //mv.movedPiece2 = brd.Tiles[0, this.Row].TilePiece;
                            //mv.Type = "Long Castle";
                            //movelist.Add(mv);
                            //TilesInVision.Add(mv);
                        }
                    }
                }
            }

            return movelist;
        }
    }
}
