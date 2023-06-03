using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class DepthFirstChessProblem : GraphSearchChessProblem
    {
        Stack<ChessProblemNode> openNodes;
        List<ChessProblemNode> closedNodes;
        bool circleDetection;

        public DepthFirstChessProblem(ChessProblemNode initialNode, bool circleDetection)
        {
            this.openNodes = new Stack<ChessProblemNode>();
            this.openNodes.Push(initialNode);
            this.closedNodes = new List<ChessProblemNode>();
            this.circleDetection = circleDetection;
        }

        public DepthFirstChessProblem() : this(new ChessProblemNode(), true) { }
        public DepthFirstChessProblem(bool circleDetection) : this(new ChessProblemNode(), circleDetection) { }

        public override ChessProblemNode Search()
        {
            if (this.circleDetection)
                return SearchTerminalNodeWithCircleDetection();
            return SearchTerminalNodeWithoutCircleDetection();
        }
        private ChessProblemNode SearchTerminalNodeWithCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                ChessProblemNode actual = openNodes.Pop();
                List<ChessProblemNode> children = actual.GetAllChildren();
                foreach (ChessProblemNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;

                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                        openNodes.Push(child);
                }
                closedNodes.Add(actual);
            }
            return null;
        }
        private ChessProblemNode SearchTerminalNodeWithoutCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                ChessProblemNode actual = openNodes.Pop();
                List<ChessProblemNode> children = actual.GetAllChildren();
                foreach (ChessProblemNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;
                    openNodes.Push(child);
                }
            }
            return null;
        }
    }
}
