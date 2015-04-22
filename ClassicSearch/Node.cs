using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicSearch
{
    class Node : IComparable<Node>
    {
        public Node Parent{ get; set; }
        public int Path_Cost { get; set; }
        public IState state { get; set; }
        public IAction action { get; set; }
        public Node[] getChilderen(IAction [] actions)
        {
            return state.getChilderen(this,actions);
        }
        public int CompareTo(Node obj)
        {
            //For DFS and BSF
            //return this.state.CompareTo(obj.state); 
            
            //For UCS
            //return (this.Path_Cost - obj.Path_Cost); 
            
            //For A* with Manhatan Distence heuristic
            return ( (this.Path_Cost + this.state.H()) - (obj.Path_Cost + this.state.H()) ); 
        }
        public static bool operator ==(Node a, Node b)
        {
            if ((object)b == null)
            {
                return (object)a == (object)b;
            }
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Node a, Node b)
        {
            if ((object)b == null)
            {
                return (object)a != (object)b;
            }
            return a.CompareTo(b) != 0;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public List<IAction> GetActionSequence()
        {
            Node temp = Parent;
            List<IAction> ActionSequence = new List<IAction>();
            ActionSequence.Add(this.action);
            while(temp.Parent != null)
            {
                ActionSequence.Add(temp.action);
                temp = temp.Parent;
            }
            return ActionSequence;
        }
    }
}
