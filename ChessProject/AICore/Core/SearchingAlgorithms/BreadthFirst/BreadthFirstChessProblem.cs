using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class BreadthFirstChessProblem : GraphSearchChessProblem
    {
        Queue<ChessProblemNode> openNodes;
        List<ChessProblemNode> closedNodes;
        bool circleDetection;

        public BreadthFirstChessProblem(bool circleDetection)
        {
            this.openNodes = new Queue<ChessProblemNode>();
            this.openNodes.Enqueue(new ChessProblemNode());
            this.closedNodes = new List<ChessProblemNode>();
            this.circleDetection = circleDetection;
        }
        public BreadthFirstChessProblem() : this(true) { }

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
                ChessProblemNode actual = openNodes.Dequeue();
                List<ChessProblemNode> children = actual.GetAllChildren();
                foreach (ChessProblemNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;

                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                        openNodes.Enqueue(child);
                }
                closedNodes.Add(actual);
            }
            return null;
        }
        private ChessProblemNode SearchTerminalNodeWithoutCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                ChessProblemNode actual = openNodes.Dequeue();
                List<ChessProblemNode> children = actual.GetAllChildren();
                foreach (ChessProblemNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;
                    openNodes.Enqueue(child);
                }
            }
            return null;
        }
    }
}
