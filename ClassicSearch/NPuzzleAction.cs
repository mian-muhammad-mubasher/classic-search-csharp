using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearchEngine
{
    abstract class NPuzzleAction : IAction
    {
        public int FindEmptyBox(IState state)
        {
            return Array.IndexOf(state.State.Split(' ').Select(e => Int32.Parse(e)).ToArray(), 0);
        }
    }
}
