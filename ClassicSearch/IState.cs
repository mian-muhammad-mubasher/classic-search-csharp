using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    abstract class IState : IComparable<IState>
    {
        public static String GoalState;
        public String State { get; set; }
        public bool GoalTest()
        {
            return State.Equals(IState.GoalState);
        }
        public Node[] getChilderen(Node Parrent, IAction [] actions)
        {
            Node [] Children = new Node[actions.Length];
            int i = 0;
            foreach (IAction action in actions)
            {
                Node Child = new Node();
                Child.state = action.PerformAction(Parrent.state);
                Child.Parent = Parrent;
                Child.Path_Cost = Parrent.Path_Cost + action.Cost;
                Child.action = action;
                Children[i] = Child;
                i++;
            }
            return Children;
        }
        public int CompareTo(IState obj)
        {
            return this.State.CompareTo(obj.State);
        }
        public abstract int H();
    }
}
