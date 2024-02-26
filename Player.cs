using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Player
    {
        string Name;
        public List<Piece> Standing;
        public List<Piece> Captured;
        private bool colourbool;

        public Player()
        {

        }
        
        public string Colour
        {
            get
            {
                if(colourbool)
                {
                    return "White";
                } else
                {
                    return "Black";
                }
            }
            set
            {
                if (value.ToLower() == "white")
                {
                    colourbool = true;
                } else
                {
                    colourbool = false;
                }
            }
        }
    }
}
