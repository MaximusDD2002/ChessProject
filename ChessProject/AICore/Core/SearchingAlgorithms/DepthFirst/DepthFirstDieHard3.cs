using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class DepthFirstDieHard3 : GraphSearchDieHard3
    {
        Stack<DieHard3Node> openNodes;
        List<DieHard3Node> closedNodes;
        bool circleDetection;

        public DepthFirstDieHard3(bool circleDetection)
        {
            this.openNodes = new Stack<DieHard3Node>();
            this.openNodes.Push(new DieHard3Node());
            this.closedNodes = new List<DieHard3Node>();
            this.circleDetection = circleDetection;
        }
        public DepthFirstDieHard3() : this(true) { }

        public override DieHard3Node Search()
        {
            if (this.circleDetection)
                return SearchTerminalNodeWithCircleDetection();
            return SearchTerminalNodeWithoutCircleDetection();
        }

        private DieHard3Node SearchTerminalNodeWithCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                DieHard3Node actual = openNodes.Pop();
                List<DieHard3Node> children = actual.GetAllChildren();
                foreach (DieHard3Node child in children)
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
        private DieHard3Node SearchTerminalNodeWithoutCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                DieHard3Node actual = openNodes.Pop();
                List<DieHard3Node> children = actual.GetAllChildren();
                foreach (DieHard3Node child in children)
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
