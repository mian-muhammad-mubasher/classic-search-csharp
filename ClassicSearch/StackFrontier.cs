using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearchEngine
{
    class StackFrontier : Stack<Node>, IFrontier
    {
        public void Add(Node obj)
        {
            Push(obj);
        }
        public Node Remove()
        {
            return Pop();
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
