using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public abstract class GraphSearchChessProblem
    {
        ChessProblemNode startNode;

        public GraphSearchChessProblem()
        {
            this.startNode = new ChessProblemNode();
        }

        public ChessProblemNode StartNode { get { return this.startNode; } }

        public abstract ChessProblemNode Search();

        public void PrintSolution(ChessProblemNode terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return;
            }

            Stack<ChessProblemNode> solution = new Stack<ChessProblemNode>();
            ChessProblemNode node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            foreach (ChessProblemNode n in solution)
            {
                Console.WriteLine(n);
            }
        }

        public Stack<ChessProblemNode> GetSolution(ChessProblemNode terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return null;
            }

            Stack<ChessProblemNode> solution = new Stack<ChessProblemNode>();
            ChessProblemNode node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            return solution;
        }

        public List<ChessProblemNode> GetSolutionAsList(ChessProblemNode terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return null;
            }

            List<ChessProblemNode> solution = new List<ChessProblemNode>();
            ChessProblemNode node = terminalNode;
            while (node != null)
            {
                solution.Insert(0,node);
                node = node.Parent;
            }

            return solution;
        }
    }
}
