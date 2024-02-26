using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Board
    {
        public Tile[,] Tiles = new Tile[8, 8];
        public List<Move> WhiteMovesInVision, BlackMovesInVision;
        public Game Game;
        private Tile StartTile, KingTile, AttackingTile;
        public Piece AttackingPiece;
        public Piece clickedPiece;
        public Board()
        {
            Game = new Game();
        }
        public Tile createTile(int col, int row)
        {
            Tile t = new Tile();
            t.column = col;
            t.row = row;
            return t;
        }
        public void createBoard()
        {
            Game.PlayerWhite.Standing = new List<Piece>();
            Game.PlayerWhite.Captured = new List<Piece>();
            Game.PlayerBlack.Standing = new List<Piece>();
            Game.PlayerBlack.Captured = new List<Piece>();
            // assign logical tiles to tile array
            // graphical will be in form class
            for (int y = 0; y < 8; y++) // row
            {
                for (int x = 0; x < 8; x++) // column
                {
                    // logical tiles

                    Tile t = createTile(x, y);
                    // assign piece to tile
                    if (y == 0 || y == 7) // 1st and 8th ranks are pieces
                    {
                        // 7 and 6 are black
                        // 1 and 0 are white
                        // 5-2 are blank

                        // piece type determined by file
                        switch (x)
                        {
                            case 0:
                                t.TilePiece = new RookR();
                                break;
                            case 7:
                                t.TilePiece = new RookR();
                                break; // rooks
                            case 1:
                                t.TilePiece = new Knight();
                                break;
                            case 6:
                                t.TilePiece = new Knight();
                                break; // knights
                            case 2:
                                t.TilePiece = new BishopR();
                                break;
                            case 5:
                                t.TilePiece = new BishopR();
                                break; // bishops
                            case 3:
                                t.TilePiece = new QueenR();
                                break;
                            case 4:
                                t.TilePiece = new King();
                                break;
                        }
                        if (y == 0) // white
                        {
                            t.TilePiece.Colour = "White";
                            Game.PlayerWhite.Standing.Add(t.TilePiece);
                        }
                        else if (y == 7)
                        {
                            t.TilePiece.Colour = "Black";
                            Game.PlayerBlack.Standing.Add(t.TilePiece);
                        }


                    }
                    else if (y == 1 || y == 6)
                    {
                        // 2nd and 7th ranks are all pawns
                        if (y == 1) // white
                        {
                            t.TilePiece = new Pawn("White");
                            Game.PlayerWhite.Standing.Add(t.TilePiece);
                        }
                        else if (y == 6)
                        {
                            t.TilePiece = new Pawn("Black");
                            Game.PlayerBlack.Standing.Add(t.TilePiece);
                        }

                    }
                    if (t.TilePiece != null)
                    {
                        t.TilePiece.Col = x;
                        t.TilePiece.Row = y;
                    }
                    Tiles[x, y] = t;
                }
            }
        }
        private void resetBlackMoves()
        {
            BlackMovesInVision = new List<Move>();
            Game.SetCheck(false);
            List<Move> tempmoves;
            foreach (Piece piece in Game.PlayerBlack.Standing)
            {
                tempmoves = piece.GetMoves(this);
                foreach (Move mv in tempmoves)
                {
                    if (mv.Type != null)
                    {
                        if (mv.Type == "Capture" && mv.capturedPiece.Name == "King")
                        {
                            AttackingPiece = mv.movedPiece;
                            KingTile = Tiles[mv.capturedPiece.Col, mv.capturedPiece.Row];
                            AttackingTile = Tiles[AttackingPiece.Col, AttackingPiece.Row];
                            Game.SetCheck(true);
                            MessageBox.Show("Check");
                        }
                    }
                }
                BlackMovesInVision.AddRange(piece.TilesInVision);
            }
        }
        private void resetWhiteMoves()
        {
            WhiteMovesInVision = new List<Move>();
            List<Move> tempmoves;
            Game.SetCheck(false);
            foreach (Piece piece in Game.PlayerWhite.Standing)
            {
                tempmoves = piece.GetMoves(this);
                foreach (Move mv in tempmoves)
                {
                    //if(mv.Type == null)
                    //{
                    //    tempmoves.Remove(mv);
                    //}
                    if (mv.Type != null)
                    {
                        if (mv.Type == "Capture" && mv.capturedPiece.Name == "King")
                        {
                            AttackingPiece = mv.movedPiece;
                            KingTile = Tiles[mv.capturedPiece.Col, mv.capturedPiece.Row];
                            AttackingTile = Tiles[AttackingPiece.Col, AttackingPiece.Row];
                            Game.SetCheck(true);
                            MessageBox.Show("Check");
                        }
                    }
                }
                WhiteMovesInVision.AddRange(piece.TilesInVision);
            }
        }

        public void MakeMove(Move mv, Game game)
        {
            game.AddMove(mv);
            StartTile = Tiles[mv.movedPiece.Col, mv.movedPiece.Row];
            Piece capturedPiece = mv.capturedPiece;
            if (mv.movedPiece.Colour == "White")
            {
                if (mv.Type.Contains("Capture")) // white capture
                {
                    MessageBox.Show("Capture");
                    game.PlayerWhite.Captured.Add(mv.capturedPiece);
                    game.PlayerBlack.Standing.Remove(mv.capturedPiece);
                    Tiles[capturedPiece.Col, capturedPiece.Row].TilePiece = null;
                }
                Game.WhiteMove = false;

            }
            else
            {
                if (mv.Type.Contains("Capture")) // black capture
                {
                    MessageBox.Show("Capture");
                    game.PlayerBlack.Captured.Add(mv.capturedPiece);
                    game.PlayerWhite.Standing.Remove(mv.capturedPiece);
                    Tiles[capturedPiece.Col, capturedPiece.Row].TilePiece = null;
                }
                Game.WhiteMove = true;
            }

            //string Name = mv.movedPiece.Name;
            //if(Name == "Rook" || Name == "Pawn" || Name == "King")
            //{
            //    mv.movedPiece.HasMoved = true;
            //}

            if (mv.Type != "Double Move" || mv.movedPiece.Name == "Rook" || mv.movedPiece.Name == "King")
            {
                mv.movedPiece.HasMoved = true;
            }
            else
            {

            }

            mv.movedPiece.MovePiece(mv.Column, mv.Row);
            Tiles[mv.Column, mv.Row].TilePiece = mv.movedPiece;
            Tiles[StartTile.column, StartTile.row].TilePiece = null;

            if (game.WhiteMove == true)
            {
                resetBlackMoves();
            }
            else
            {
                resetWhiteMoves();
            }
            if(game.IsInCheck())
            {
                List<Move> uncheck = GetUncheckMoves();
                if(uncheck.Count<Move>() == 0)
                {
                    game.CheckMate = true;
                }
            }
        }
        //public void MakeMove(Move mv)
        //{
        //    mv.movedPiece.MovePiece(mv.Column, mv.Row);
        //    Tiles[mv.Column, mv.Row].TilePiece = mv.movedPiece;
        //    if(mv.Type == "Capture")
        //    {
        //        if(mv.capturedPiece.Colour == "White")
        //        {
        //            PlayerBlack.Captured.Add(mv.capturedPiece);
        //            PlayerWhite.Standing.Remove(mv.capturedPiece);
        //        } else
        //        {
        //            PlayerWhite.Captured.Add(mv.capturedPiece);
        //            PlayerBlack.Standing.Remove(mv.capturedPiece);
        //        }
        //    }

        //    resetWhiteMoves();
        //    resetBlackMoves();
        //}
        public bool IsThisTileInVision(Move mv)
        {
            Piece king = mv.movedPiece;
            //if(king.Colour == "White")
            //{
            //    foreach(Piece piece in BlackPieces)
            //    {
            //        if(king.Row - piece.Row > 3 && (piece.Name == "Pawn" || piece.Name == "Knight"))
            //        {
            //            return false;
            //        } else
            //        {
            //            foreach (Move move in piece.GetMoves(this)) // search for EVERY legal move by EVERY opposing piece
            //            {
            //                if (Tiles[move.Column, move.Row] == Tiles[mv.Column, mv.Row]) // if a move matches where the king can move
            //                {
            //                    return true;
            //                }
            //            }
            //        }


            //    }
            //} else
            //{
            //    foreach(Piece piece in WhitePieces)
            //    {
            //        if (piece.Row - king.Row > 3 && (piece.Name == "Pawn" || piece.Name == "Knight"))
            //        {
            //            return false;
            //        }
            //        else
            //        {
            //            foreach (Move move in piece.GetMoves(this)) // search for EVERY legal move by EVERY opposing piece
            //            {
            //                if (Tiles[move.Column, move.Row] == Tiles[mv.Column, mv.Row]) // if a move matches where the king can move
            //                {
            //                    return true;
            //                }
            //            }
            //        }
            //    }
            //}

            if (king.Colour == "White")
            {
                if (BlackMovesInVision == null)
                {
                    return true;
                }
                else
                {
                    // this loop checks if the specified tile is free (returning true if the tile is NOT free)
                    foreach (Move mov in BlackMovesInVision)
                    {
                        if (mov.Column == mv.Column && mov.Row == mv.Row)
                        {
                            return true;
                            break;
                        }
                    }

                    // however, even if a tile is initially free, the king shouldn't be able to move such that a piece can then capture it
                    // this is why a TilesInVision list exists for each piece, showing every possible square that a piece is able to capture on (assuming a piece was on it)
                }
            }
            else
            {
                if (WhiteMovesInVision == null)
                {
                    return true;
                }
                else
                {
                    foreach (Move mov in WhiteMovesInVision)
                    {
                        if (mov.Column == mv.Column && mov.Row == mv.Row)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Move> GetClickedPieceMoves()
        {
            List<Move> movelist = new List<Move>();
            Move mv;
            
            if ((Game.WhiteMove == true && clickedPiece.Colour == "White") || (Game.WhiteMove == false && clickedPiece.Colour == "Black"))
            {
                if (Game.IsInCheck() == false)
                {
                    //MessageBox.Show("Game is not in check");
                    foreach (Move mov in clickedPiece.GetMoves(this))
                    {
                        movelist.Add(mov);
                    }
                }
                else if (Game.IsInCheck() == true)
                {
                    //MessageBox.Show("Game is in check");
                    List<Move> AttackingMoves = AttackingPiece.GetMoves(this);

                    if (clickedPiece.Name == "King")
                    {
                        foreach (Move kingmove in clickedPiece.GetMoves(this))
                        {
                            movelist.Add(kingmove);
                            //UnCheckMoves.Add(kingmove);
                        }
                    }
                    else
                    {
                        foreach(Move uncheck in GetUncheckMoves())
                        {
                            if(uncheck.movedPiece == clickedPiece)
                            {
                                MessageBox.Show("Uncheck move found");
                                movelist.Add(uncheck);
                            }
                        }
                        //VisionTiles = GetTilesInVision();
                        ////MessageBox.Show("Moves computed");
                        //foreach (Move clickedmv in clickedPiece.GetMoves(this))
                        //{
                        //    // Can the attacking piece be captured?
                        //    if (clickedmv.capturedPiece == AttackingPiece)
                        //    {
                        //        //MessageBox.Show("Capture found");
                        //        movelist.Add(clickedmv);
                        //        UnCheckMoves.Add(clickedmv);
                        //    }
                        //    else
                        //    {

                        //        foreach (Move attmv in VisionTiles)
                        //        {
                        //            if (clickedmv.Column == attmv.Column && clickedmv.Row == attmv.Row)
                        //            {
                        //                //MessageBox.Show("Move found");
                        //                movelist.Add(clickedmv);
                        //                UnCheckMoves.Add(clickedmv);
                        //            }
                        //        }


                        //    }
                        //}
                        // if uncheckmoves is null, there are no moves that can take the game out of check
                        //else
                        //{
                        //    movelist = UnCheckMoves;
                        //} //gonna check this later
                    }
                }
            }

            return movelist;
        }

        public List<Move> GetUncheckMoves()
        {
            List<Move> UnCheckMoves = new List<Move>();

            List<Move> VisionTiles = GetTilesInVision();
            //MessageBox.Show("Moves computed");
            if(Game.WhiteMove == true)
            {
                foreach (Move whitemv in WhiteMovesInVision)
                {
                    if(whitemv.Type != null)
                    {
                        // Can the attacking piece be captured?
                        if (whitemv.capturedPiece == AttackingPiece)
                        {
                            //MessageBox.Show("Capture found");
                            UnCheckMoves.Add(whitemv);
                        }
                        else
                        {
                            // Can the line of sight be blocked?
                            foreach (Move attmv in VisionTiles)
                            {
                                if (whitemv.Column == attmv.Column && whitemv.Row == attmv.Row)
                                {
                                    //MessageBox.Show("Move found");
                                    UnCheckMoves.Add(whitemv);
                                }
                            }
                        }
                    }
                }
            } else
            {
                foreach (Move blackmv in BlackMovesInVision)
                {
                    if (blackmv.Type != null)
                    {
                        // Can the attacking piece be captured?
                        if (blackmv.capturedPiece == AttackingPiece)
                        {
                            //MessageBox.Show("Capture found");
                            UnCheckMoves.Add(blackmv);
                        }
                        else
                        {
                            // Can the line of sight be blocked?
                            foreach (Move attmv in VisionTiles)
                            {
                                if (blackmv.Column == attmv.Column && blackmv.Row == attmv.Row)
                                {
                                    //MessageBox.Show("Move found");
                                    UnCheckMoves.Add(blackmv);
                                }
                            }
                        }
                    }
                }
            }


            return UnCheckMoves;
        }

        public List<Move> GetTilesInVision()
        {
            List<Move> VisionTiles = new List<Move>();
            Move mv;

            // attackingtile is where the attacking piece (e.g. queen, bishop) lies
            // kingtile is where the opposing king lies
            int numberofcolsmovedfromking = KingTile.column - AttackingTile.column;
            int numberofrowsmovedfromking = KingTile.row - AttackingTile.row; // attackingtile and kingtile are global variables

            
            // Can the line of sight of the attacking piece be blocked?

            // if the magnitude of the number of columns moved is equal to the magnitude of the number of rows moved (e.g. 3 right -3 up) then the move is a diagonal AND numberofrows moved is non-zero (by extension, numberofcols moved is also non-zero)
            if (AttackingPiece.Name == "Bishop" || (AttackingPiece.Name == "Queen" && Math.Abs(numberofcolsmovedfromking) == Math.Abs(numberofrowsmovedfromking) && numberofrowsmovedfromking != 0))
            {
                // diagonals
                if(numberofcolsmovedfromking < 0)
                {
                    // if less than zero, attacking piece is right of king
                    if(numberofrowsmovedfromking < 0)
                    {
                        // if less than zero, attacking piece is above king

                        // in this case, return the tiles diagonally right and above of the king

                        for(int i = 1; i < Math.Abs(numberofrowsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column + i;
                            mv.Row = KingTile.row + i;
                            VisionTiles.Add(mv);
                        }

                    } else if(numberofrowsmovedfromking > 0)
                    {
                        // if more than zero, attacking piece is below king

                        for (int i = 1; i < Math.Abs(numberofrowsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column + i;
                            mv.Row = KingTile.row - i;
                            VisionTiles.Add(mv);
                        }
                    }
                } else if(numberofcolsmovedfromking > 0)
                {
                    // if more than zero, attacking piece is left of king

                    if (numberofrowsmovedfromking < 0)
                    {
                        // if less than zero, attacking piece is above king

                        for (int i = 1; i < Math.Abs(numberofrowsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column - i;
                            mv.Row = KingTile.row + i;
                            VisionTiles.Add(mv);
                        }
                    }
                    else if (numberofrowsmovedfromking > 0)
                    {
                        // if more than zero, attacking piece is below king 

                        for (int i = 1; i < Math.Abs(numberofrowsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column - i;
                            mv.Row = KingTile.row - i;
                            VisionTiles.Add(mv);
                        }
                    }

                } else if(numberofcolsmovedfromking == 0)
                {
                    // if zero, attacking piece is on the same column as king
                    // this goes in straight lines
                }
            }
            else if (AttackingPiece.Name == "Rook" || (AttackingPiece.Name == "Queen" && (numberofcolsmovedfromking == 0 || numberofrowsmovedfromking == 0)))
            {
                // straight lines
                if(numberofcolsmovedfromking == 0)
                {
                    // same column

                    if(numberofrowsmovedfromking < 0)
                    {
                        // attacking piece is above king

                        for (int i = 1; i < Math.Abs(numberofrowsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column;
                            mv.Row = KingTile.row + i;
                            VisionTiles.Add(mv);
                        }
                    } else if(numberofrowsmovedfromking > 0)
                    {
                        // attacking piece is below king

                        for (int i = 1; i < Math.Abs(numberofrowsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column;
                            mv.Row = KingTile.row - i;
                            VisionTiles.Add(mv);
                        }
                    }
                } else if(numberofrowsmovedfromking == 0)
                {
                    // same row

                    if(numberofcolsmovedfromking < 0)
                    {
                        // attacking piece is right of king

                        for (int i = 1; i < Math.Abs(numberofcolsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column + i;
                            mv.Row = KingTile.row;
                            VisionTiles.Add(mv);
                        }
                    } else if(numberofcolsmovedfromking > 0)
                    {
                        // attacking piece is left of king

                        for (int i = 1; i < Math.Abs(numberofcolsmovedfromking); i++)
                        {
                            mv = new Move();
                            mv.Column = KingTile.column - i;
                            mv.Row = KingTile.row;
                            VisionTiles.Add(mv);
                        }
                    }
                }
            }

            return VisionTiles;
        }
    }
}
