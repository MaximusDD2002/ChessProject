using System;
using AICore;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChessProblemState state = new ChessProblemState();
            //Console.Write(state.ToString());
            //Console.WriteLine("Is{0} a valid state", state.IsState() ? "" : " not");
            //Console.WriteLine("Is{0} a goal state", state.IsGoalState() ? "" : " not");
            //Console.WriteLine();

            //char[,] board = new char[,]
            //{
            //    { '0', '#', '#', '#', '#' },
            //    { '#', 'K', 'B', 'B', '#' },
            //    { '#', 'R', 'R', '0', '#' },
            //    { '#', '#', '#', '#', '#' }
            //};
            //ChessProblemState falseState = new ChessProblemState(board);
            //Console.Write(falseState.ToString());
            //Console.WriteLine("Is{0} a valid state", falseState.IsState() ? "" : " not");
            //Console.WriteLine("Is{0} a goal state", falseState.IsGoalState() ? "" : " not");

            //char[,] goal = new char[,]
            //{
            //    { '#', '#', '#', '#', '#' },
            //    { '#', 'B', 'B', '0', '#' },
            //    { '#', 'R', 'R', 'K', '#' },
            //    { '#', '#', '#', '#', '#' }
            //};
            //ChessProblemState goalState = new ChessProblemState(goal);
            //Console.Write(goalState.ToString());
            //Console.WriteLine("Is{0} a valid state", goalState.IsState() ? "" : " not");
            //Console.WriteLine("Is{0} a goal state", goalState.IsGoalState() ? "" : " not");


            //Console.WriteLine(state.ApplyOperator(1, 2, Direction8.DownRight));
            //Console.Write(state.ToString());

            BacktrackChessProblem backChessProblem = new BacktrackChessProblem(100, true);

            ChessProblemNode backSolution = backChessProblem.Search();

            backChessProblem.PrintSolution(backSolution);
        }
    }
}
