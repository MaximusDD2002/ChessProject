using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public abstract class GraphSearchDieHard3
    {
        DieHard3Node startNode;

        public GraphSearchDieHard3()
        {
            this.startNode = new DieHard3Node();
        }

        public DieHard3Node StartNode { get { return this.startNode; } }

        public abstract DieHard3Node Search();

        public void PrintSolution(DieHard3Node terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return;
            }

            Stack<DieHard3Node> solution = new Stack<DieHard3Node>();
            DieHard3Node node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            foreach (DieHard3Node n in solution)
            {
                Console.WriteLine(n);
            }
        }

        public Stack<DieHard3Node> GetSolution(DieHard3Node terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return null;
            }

            Stack<DieHard3Node> solution = new Stack<DieHard3Node>();
            DieHard3Node node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            return solution;            
        }
    }
}
