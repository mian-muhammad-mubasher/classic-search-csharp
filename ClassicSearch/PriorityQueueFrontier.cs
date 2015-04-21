using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ClassicSearchEngine
{
    class PriorityQueueFrontier : OrderedBag<Node> , IFrontier
    {
        public void Add(Node obj)
        {
            base.Add(obj);
        }
        public Node Remove()
        {
            return base.RemoveFirst();
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
