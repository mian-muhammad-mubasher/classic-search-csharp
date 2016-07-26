using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//hahahaah
//ewrwerwtwrtrtet

namespace ClassicSearch
{
    class Program
    {
        static bool flag = false;
        static void Main(string[] args)
        {
            int NoOfTestCases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < NoOfTestCases; i++)
            {
                Console.Write("Test Case Number " + i +" : ");
                String InitialStateStr = Console.ReadLine();
                String GoalStateStr = MakeGoalStateStringRepresentationForNPuzzle(InitialStateStr);

                IState.GoalState = GoalStateStr;
                NPuzzleState InitialState = new NPuzzleState();
                InitialState.State = InitialStateStr;

                Node InitialStateNode = new Node();
                InitialStateNode.action = null;
                InitialStateNode.Parent = null;
                InitialStateNode.Path_Cost = 0;
                InitialStateNode.state = InitialState;

                IAction [] actions = new IAction[4];
                actions[0] = new NPuzzleActionUp();
                actions[0].Name = "MoveUp";
                actions[0].Cost = 1;
                actions[1] = new NPuzzleActionDown();
                actions[1].Name = "MoveDown";
                actions[1].Cost = 1;
                actions[2] = new NpuzzleActionLeft();
                actions[2].Name = "MoveLeft";
                actions[2].Cost = 1;
                actions[3] = new NPuzzleActionRight();
                actions[3].Name = "MoveRight";
                actions[3].Cost = 1;

                List<IState> ExploredStates = new List<IState>();
                //For BFS
                //IFrontier Frontier = new QueueFrontier();
                
                //For DFS
                //IFrontier Frontier = new StackFrontier();
                
                //For UCS and A*
                IFrontier Frontier = new PriorityQueueFrontier();
                
                Frontier.Add(InitialStateNode);
                ExploredStates.Add(InitialStateNode.state);
                //Console.WriteLine(InitialState.H());

                //double j = 0;
                while(!Frontier.IsEmpty())
                {
                    Node StateUnderObservation = Frontier.Remove();
                    //j = j + 1;
                    //Console.WriteLine("States Explored untill Now = " + j);
                    if(StateUnderObservation.state.GoalTest())
                    {
                        flag = true;
                        List<IAction> ActionSequence = StateUnderObservation.GetActionSequence();
                        Stack<IAction> ReverseActionSequence = new Stack<IAction>();
                        foreach (IAction action in ActionSequence)
                        {
                            ReverseActionSequence.Push(action);
                        }
                        while (ReverseActionSequence.Count != 0)
                        {
                            IAction tempAction = ReverseActionSequence.Pop();
                            Console.Write(tempAction.Name + "->");
                        }
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        //ExploredStates.Add(StateUnderObservation.state);
                        Node [] Expensions = StateUnderObservation.getChilderen(actions);
                        //Expensions = Expensions.Except(ExploredStates).ToArray();
                        foreach (Node exp in Expensions)
                        {
                            if (!ExploredStates.Any(x => x.State.Equals(exp.state.State)))
                            {
                                Frontier.Add(exp);
                                ExploredStates.Add(exp.state);
                                //Console.WriteLine("States Explored are: "+ExploredStates.Count);
                                //Console.WriteLine("State is: "+exp.state.State);
                                //Console.WriteLine("Heuristic on this state is: "+exp.state.H());
                            }
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Solution Not Possible");
                }
                flag = false;
            }

            Thread.Sleep(2);
        }
        static String MakeGoalStateStringRepresentationForNPuzzle(String stateStr)
        {
            Int32[] goalStateInt = stateStr.Split(' ').Select(e => Int32.Parse(e)).ToArray();
            Array.Sort(goalStateInt);
            return String.Join(" ", goalStateInt);
        }
    }
}
