using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace chessy
{
    public class Tile
    {
        public int column;
        public int row;
        public Piece TilePiece;
        public Image image;
        public Tile()
        {
            if(TilePiece == null) // nothing on the tile
            {
                // render blank tile image
            } else // something on the tile
            {
                // render piece tile image based on piece and color
            }
        }
    }
}
