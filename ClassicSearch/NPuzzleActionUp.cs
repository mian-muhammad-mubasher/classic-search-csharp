using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    class NPuzzleActionUp : NPuzzleAction
    {
        public override IState PerformAction(IState state)
        {
            Int32[] stateInt = state.State.Split(' ').Select(e => Int32.Parse(e)).ToArray();
            int problemDimension = (int)Math.Sqrt(stateInt.Length);
            int EmptyBoxIndex = FindEmptyBox(state);
            if ( EmptyBoxIndex < problemDimension )
            {
                return state;
            }
            else
            {
                int temp = stateInt[EmptyBoxIndex - problemDimension];
                stateInt[EmptyBoxIndex - problemDimension] = stateInt[EmptyBoxIndex];
                stateInt[EmptyBoxIndex] = temp;
            }
            IState ChildState = new NPuzzleState();
            ChildState.State = string.Join(" ", stateInt);
            return ChildState;
        }
    }
}
