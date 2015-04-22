using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    interface IFrontier
    {
        void Add(Node obj);
        Node Remove();
        bool IsEmpty();
    }
}
