using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    /* the way I want to tackle this is that I want to be able
     * to add (such as promotion) and remove pieces (such as captures) dynamically
     * this is because a game of chess will never have 16 pieces per player all the time
     * pieces will be captured and promoted at many points during a game of chess
     * one big hurdle for me, though, is that many different pieces will be captured
     * this means that I won't be able to remove the last or first indexes from my list like in a traditional stack or queue
     */
    internal class LinkList
    {
        public Node Head;
        public Node Tail;
        public Node Current;
    }
}
