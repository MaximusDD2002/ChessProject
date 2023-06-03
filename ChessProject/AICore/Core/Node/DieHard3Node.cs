using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class DieHard3Node
    {
        DieHard3State state;
        int depth;
        DieHard3Node parent;

        public DieHard3Node()
        {
            this.state = new DieHard3State();
            this.depth = 0;
            this.parent = null;
        }
        public DieHard3Node(DieHard3Node parent)
        {
            this.state = (DieHard3State)parent.state.Clone();
            this.depth = parent.depth + 1;
            this.parent = parent;
        }

        public DieHard3Node Parent { get { return parent; } }
        public DieHard3State State { get { return this.state; } }
        public int Depth { get { return depth; } }
        public bool IsTerminalNode { get { return state.IsGoalState(); } }
        public List<DieHard3Node> GetAllChildren()
        {
            List<DieHard3Node> children = new List<DieHard3Node>();
            for (int can = 0; can < 2; can++)
            {
                for (int action = 0; action < 3; action++)
                {
                    bool isCan3 = can == 0;
                    CanActions canAction = (CanActions)action;

                    DieHard3Node childNode = new DieHard3Node(this);
                    if (childNode.state.ApplyOperator(isCan3, canAction))
                        children.Add(childNode);
                }
            }
            return children;
        }

        public override bool Equals(object obj)
        {
            DieHard3Node other = (DieHard3Node)obj;
            return this.state.Equals(other.state);
        }

        public override string ToString()
        {
            return state.ToString();
        }
    }
}
