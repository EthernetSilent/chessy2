using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Move
    {
        /*enum color
        {

        }

        */
        public string Type; // capture or move
        public string PGN;
        public int Row, Column; // row and column refer to where the piece will move
        public Piece movedPiece, movedPiece2;
        public Piece capturedPiece; // piece that will be removed from board upon capture
        public int Rank()
        {
            return Row + 1;
        }
        public int File()
        {
            return Column + 1;
        }
    }
}
