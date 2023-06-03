using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class BacktrackChessProblem : GraphSearchChessProblem
    {
        private int maxDepth;
        private bool isMemorable;

        public BacktrackChessProblem(ChessProblemNode initialNode, int maxDepth, bool isMemorable)
        {
            this.maxDepth = maxDepth;
            this.isMemorable = isMemorable;
        }

        public BacktrackChessProblem() : this(new ChessProblemNode(), 0, false) { }
        public BacktrackChessProblem(int maxDepth) : this(new ChessProblemNode(), maxDepth, false) { }
        public BacktrackChessProblem(bool isMemorable) : this(new ChessProblemNode(), 0, isMemorable) { }
        public BacktrackChessProblem(int maxDepth, bool isMemorable) 
            : this(new ChessProblemNode(), maxDepth, isMemorable) { }

        public override ChessProblemNode Search()
        {
            return Search(StartNode);
        }

        private ChessProblemNode Search(ChessProblemNode actualNode)
        {
            int actualDepth = actualNode.Depth;

            //Check if we reached the maximum depth
            if (maxDepth != 0 && actualDepth >= maxDepth)
                return null;

            //Check if we already checked the same node
            if (isMemorable && actualDepth > 0)
                if (GetSolution(actualNode.Parent).Contains(actualNode)) return null;

            //Check if the actual node is a terminal node
            if (actualNode.IsTerminalNode)
                return actualNode;

            //Select a new node

            int xLength = actualNode.State.GetXLength;
            int yLength = actualNode.State.GetYLength;

            for (int i = 1; i < xLength - 1; i++)
            {
                for (int u = 1 ; u < yLength - 1; u++)
                {
                    for (int dir = 0; dir < 8; dir++)
                    {
                        ChessProblemNode newNode = new ChessProblemNode(actualNode);
                        if (newNode.State.ApplyOperator(i, u, (Direction8)dir))
                        {
                            ChessProblemNode terminalNode = Search(newNode);
                            if (terminalNode != null)
                                return terminalNode;
                        }
                    }
                }
            }

            return null; //There is no solution of the problem
        }
    }
}
