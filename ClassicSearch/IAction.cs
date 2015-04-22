using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    abstract class IAction
    {
        public int Cost { get; set; }
        public String Name { get; set; }
        public abstract IState PerformAction(IState state);
    }
}
