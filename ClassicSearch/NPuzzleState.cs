using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    class NPuzzleState : IState
    {
        public override int H()
        {
            int sum = 0;
            Int32[] stateInt = State.Split(' ').Select(e => Int32.Parse(e)).ToArray();
            for (int i = 0; i < stateInt.Length; i++)
            {
                sum = sum + Math.Abs(stateInt[i] - i);
            }
            return sum;
        }
    }
}
