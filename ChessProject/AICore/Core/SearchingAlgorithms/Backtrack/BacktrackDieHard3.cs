using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class BacktrackDieHard3 : GraphSearchDieHard3
    {
        private int maxDepth;
        private bool isMemorable;

        public BacktrackDieHard3(int maxDepth, bool isMemorable)
        {
            this.maxDepth = maxDepth;
            this.isMemorable = isMemorable;
        }
        public BacktrackDieHard3() : this(0, false) { }
        public BacktrackDieHard3(int maxDepth) : this(maxDepth, false) { }
        public BacktrackDieHard3(bool isMemorable) : this(0, isMemorable) { }

        public override DieHard3Node Search()
        {
            return Search(StartNode);
        }

        private DieHard3Node Search(DieHard3Node actualNode)
        {
            int actualDepth = actualNode.Depth;

            //Check if we reached the maximum depth
            if (maxDepth != 0 && actualDepth >= maxDepth)
                return null;

            //Check if we already checked the same node
            DieHard3Node actualParent = null;
            if (isMemorable)
                actualParent = actualNode.Parent;
            while (actualParent != null)
            {
                if (actualNode.Equals(actualParent))
                    return null;
                actualParent = actualParent.Parent;
            }

            //Check if the actual node is a terminal node
            if (actualNode.IsTerminalNode)
                return actualNode;

            //Select a new node
            for (int can = 0; can < 2; can++)
            {
                for (int action = 0; action < 3; action++)
                {
                    DieHard3Node newNode = new DieHard3Node(actualNode);
                    if (newNode.State.ApplyOperator(can == 0, (CanActions)action))
                    {
                        DieHard3Node terminalNode = Search(newNode);
                        if (terminalNode != null)
                            return terminalNode;
                    }
                }
            }

            return null; //There is no solution of the problem
        }
    }
}
