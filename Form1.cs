using System.Drawing;
namespace chessy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Board = new Board();
            Board.createBoard();
            DrawTable();
        }
        public Board Board;
        public TableLayoutPanel BoardTable;
        public static Random rnd = new Random();
        public int tempIndex;
        private bool highlight;
        //public Piece tempPiece;
        public List<Move> SelectMoves, clickedPieceMoves;
        private void DrawTable()
        {

            //MessageBox.Show("RESET COLOURS AND CLICK EVENTS");

            if (this.Controls.Contains(BoardTable))
            {
                // if boardtable has been initialised
                //int col, row;
                //PictureBox pb;
                //// reset colours and click events of pictureboxes
                //Control temp = BoardTable;
                this.Controls.Remove(BoardTable);
            }
                BoardTable = new TableLayoutPanel
                {
                    ColumnCount = 8,
                    RowCount = 8,
                    Size = new Size(480, 480)
                };

                for (int y = 7; y >= 0; y--)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        Board.Tiles[x, y].column = x; // complete a row first before a column
                        Board.Tiles[x, y].row = y;
                        BoardTable.Controls.Add(AssignPBToTile(Board.Tiles[x, y]));

                    }
                }

                //BoardTable.Refresh();
                this.Controls.Add(BoardTable);
            
            
            
            
            if (Board.Game.CheckMate == true)
            {
                MessageBox.Show("Checkmate");
                this.Close();
            }
            Label lbl = new Label();
            for (int x = 7; x > -1; x--)
            {
                lbl = new Label()
                {
                    AutoSize = true,
                    Text = $"{x + 1}",
                    Font = new Font("Segoe UI", 24),
                    Location = new Point(480, ((7 - x) * 60) + 8),
                };

                this.Controls.Add(lbl);
            }

            for (int x = 0; x < 8; x++)
            {
                lbl = new Label
                {
                    AutoSize = true,
                    Text = $"{Convert.ToChar(x + 97)}",
                    Font = new Font("Segoe UI", 24),
                    Location = new Point((x * 60) + 10, 480)
                };

                this.Controls.Add(lbl);
            }
        }
        private PictureBox AssignColourToPB(PictureBox pb)
        {
            int row = Convert.ToInt32(pb.Name[1].ToString()) - 1;
            int col = Convert.ToInt32(pb.Name[0] - 97);
            if (row % 2 == 0) // if even then both even to be lightsquare
            {
                if (col % 2 == 0)
                {
                    pb.BackColor = Color.PeachPuff;
                }
                else
                {
                    pb.BackColor = Color.Peru;
                }
            }
            else
            {
                if (col % 2 == 1)
                {
                    pb.BackColor = Color.PeachPuff;
                }
                else
                {
                    pb.BackColor = Color.Peru;
                }
            }
            return pb;
        }
        public PictureBox AssignPBToTile(Tile t)
        {
            PictureBox pb = new PictureBox();

            char file = Convert.ToChar(t.column + 97);
            pb.Name = $"{file}{t.row + 1}"; // e.g. a4, b5, d8, etc
            pb.Width = 60;
            pb.Height = 60;
            pb.Margin = new Padding(0);
            //pb.Dock = DockStyle.Fill;

            pb = AssignColourToPB(pb);

            // if tile present
            if(t.TilePiece == null)
            {
                pb.Click += BlankPBClicked;
            } else
            {
                switch (t.TilePiece.Colour)
                {
                    case "Black": // dark
                        switch (t.TilePiece)
                        {
                            case Pawn:
                                pb.Image = Image.FromFile("../bmp/Chess_pdt60.png");
                                break;
                            case Knight:
                                pb.Image = Image.FromFile("../bmp/Chess_ndt60.png");
                                break;
                            case Rook:
                                pb.Image = Image.FromFile("../bmp/Chess_rdt60.png");
                                break;
                            case RookR:
                                pb.Image = Image.FromFile("../bmp/Chess_rdt60.png");
                                break;
                            case Bishop:
                                pb.Image = Image.FromFile("../bmp/Chess_bdt60.png");
                                break;
                            case BishopR:
                                pb.Image = Image.FromFile("../bmp/Chess_bdt60.png");
                                break;
                            case Queen:
                                pb.Image = Image.FromFile("../bmp/Chess_qdt60.png");
                                break;
                            case QueenR:
                                pb.Image = Image.FromFile("../bmp/Chess_qdt60.png");
                                break;
                            case King:
                                pb.Image = Image.FromFile("../bmp/Chess_kdt60.png");
                                break;
                        }
                        break;
                    case "White": // light
                        switch (t.TilePiece)
                        {
                            case Pawn:
                                pb.Image = Image.FromFile("../bmp/Chess_plt60.png");
                                break;
                            case Knight:
                                pb.Image = Image.FromFile("../bmp/Chess_nlt60.png");
                                break;
                            case Rook:
                                pb.Image = Image.FromFile("../bmp/Chess_rlt60.png");
                                break;
                            case RookR:
                                pb.Image = Image.FromFile("../bmp/Chess_rlt60.png");
                                break;
                            case Bishop:
                                pb.Image = Image.FromFile("../bmp/Chess_blt60.png");
                                break;
                            case BishopR:
                                pb.Image = Image.FromFile("../bmp/Chess_blt60.png");
                                break;
                            case Queen:
                                pb.Image = Image.FromFile("../bmp/Chess_qlt60.png");
                                break;
                            case QueenR:
                                pb.Image = Image.FromFile("../bmp/Chess_qlt60.png");
                                break;
                            case King:
                                pb.Image = Image.FromFile("../bmp/Chess_klt60.png");
                                break;
                            default:
                                pb.Image = Image.FromFile("../bmp/Chess_blt60.png");
                                break;
                        }
                        break;
                }
                pb.Click += PiecePBClicked;
            }
            
            pb.BorderStyle = BorderStyle.FixedSingle;
            return pb;
        }
        public void SetPBAttributes(PictureBox pb)
        {

        }
        private void PiecePBClicked(object sender, EventArgs e)
        {
            // picturebox indexes 0-7 are a1 to h1, 8-15 are a2 to h2, etc
            PictureBox pb = sender as PictureBox;
            int column = Convert.ToInt32(pb.Name[0]) - 97;
            int row = Convert.ToInt32(pb.Name[1].ToString()) - 1; // a is column 0, row is 4 in 'a4'
            int index;

            

            SelectMoves = new List<Move>();
            if(highlight == true)
            {
                DrawTable();
                highlight = false;
            }
            Board.clickedPiece = Board.Tiles[column, row].TilePiece;

            foreach(Move move in Board.GetClickedPieceMoves())
            {
                HighlightMove(move);
            }
            

            //if ((piece.Colour == "White" && Board.Game.WhiteMove == true) || (piece.Colour == "Black" && Board.Game.WhiteMove == false))
            //{
            //    if((Board.Game.Check == false) || (Board.Game.Check == true && piece.Name == "King"))
            //    {
            //        DrawTable();
            //        tempMoves = new List<Move>();
            //        foreach (Move mv in piece.GetMoves(Board))
            //        {
            //            row = mv.Row;
            //            column = mv.Column;
            //            index = ((7 - row) * 8) + column;

            //            tempMoves.Add(mv);

            //            //MessageBox.Show($"Move at {BoardTable.Controls[index].Name} added to tempMoves");
            //            BoardTable.Controls[index].BackColor = Color.Aquamarine;

            //            if (mv.Type != "Capture")
            //            {
            //                BoardTable.Controls[index].Click -= BlankPBClicked;
            //            }
            //            else
            //            {
            //                BoardTable.Controls[index].Click -= PiecePBClicked;
            //            }

            //            BoardTable.Controls[index].Click += HighlightedMoveClicked;

            //        }
            //    }

                //MessageBox.Show($"This is a {piece.Colour} {piece.Name} at {pb.Name} and index {index}, row {piece.Row} and column {piece.Col}: ");
            //}

        }

        private void HighlightMove(Move mv)
        {
            highlight = true;
            int row = mv.Row;
            int column = mv.Column;
            int index = ((7 - row) * 8) + column;
            SelectMoves.Add(mv);
            BoardTable.Controls[index].BackColor = Color.Aquamarine;
            if (mv.Type != "Capture")
            {
                BoardTable.Controls[index].Click -= BlankPBClicked;
            }
            else
            {
                BoardTable.Controls[index].Click -= PiecePBClicked;
            }
            BoardTable.Controls[index].Click += HighlightedMoveClicked;
        }

        private void BlankPBClicked(object sender, EventArgs e)
        {
            //DrawTable();
            //PictureBox pb = sender as PictureBox;
            //int column = Convert.ToInt32(pb.Name[0]) - 97;
            //int row = Convert.ToInt32(pb.Name[1].ToString()) - 1; // a is column 0, row is 4 in 'a4'
            //int index = ((7 - row) * 8) + column;
            //MessageBox.Show($"This is a blank tile at {pb.Name} and index {index}");
        }

        private void HighlightedMoveClicked(object sender, EventArgs e) // this makes the move
        {
            PictureBox pb = sender as PictureBox;
            //MessageBox.Show($"Highlighted move clicked at tile {pb.Name}");
            int pbColumn = Convert.ToInt32(pb.Name[0]) - 97;
            int pbRow = Convert.ToInt32(pb.Name[1].ToString()) - 1; // a is column 0, row is 4 in 'a4'
            // this is the row and column of the highlighted tile (picturebox)

            // Board.Tiles[hColumn, hRow].TilePiece = tempPiece;
            // Board.Tiles[tempColumn, tempRow].TilePiece = null;

            //Board.Tiles[pbColumn, pbRow].TilePiece = tempPiece;
            //Board.Tiles[tempPiece.Col, tempPiece.Row].TilePiece = null;

            //tempIndex = (tempPiece.Row * 8) + tempPiece.Col; // the piece is not there, so set the event as blank tile
            //BoardTable.Controls[tempIndex].Click -= PiecePBClicked;
            //BoardTable.Controls[tempIndex].Click += BlankPBClicked;

            foreach(Move mv in SelectMoves)
            {
                if(mv.Row == pbRow && mv.Column == pbColumn) // if the picturebox corresponds to a move location
                {
                    //Board.Tiles[mv.Column, mv.Row].TilePiece = mv.movedPiece;
                    
                    if(mv.movedPiece.Colour == "White" && Board.Game.WhiteMove == true)
                    {
                        Board.MakeMove(mv, Board.Game);

                    } else if(mv.movedPiece.Colour == "Black" && Board.Game.WhiteMove == false)
                    {
                        Board.MakeMove(mv, Board.Game);
                    }
                }
            }
            //MessageBox.Show("Move made");
            DrawTable();
        }
    }
}