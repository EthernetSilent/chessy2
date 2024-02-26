using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Node
    {
        public int ID;
        public Node Left;
        public string Data;
        public Node Right;
        public static int No;

        public Node()
        {
            No++;
        }
        public int GetNo()
        {
            return No;
        }
    }
}
