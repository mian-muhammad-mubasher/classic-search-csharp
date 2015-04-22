using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    class QueueFrontier : Queue<Node>, IFrontier
    {
        public void Add(Node obj)
        {
            Enqueue(obj);
        }
        public Node Remove()
        {
            return Dequeue();
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
