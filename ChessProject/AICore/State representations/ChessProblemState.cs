using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class ChessProblemState : AbstractState, IOperatorHandler<bool, CanActions>
    {
        char[,] chessboard;

        /// <summary>
        /// K - king
        /// B - bishop
        /// R - rook
        /// 
        /// 0 - empty square
        /// </summary>

        static char[,] GOAL = new char[,]
        {
            { '#', '#', '#', '#', '#' },
            { '#', 'B', 'B', '0', '#' },
            { '#', 'R', 'R', 'K', '#' },
            { '#', '#', '#', '#', '#' }
        };

        public ChessProblemState()
        {
            this.chessboard = new char[,]
            {
                { '#', '#', '#', '#', '#' },
                { '#', 'K', 'B', 'B', '#' },
                { '#', 'R', 'R', '0', '#' },
                { '#', '#', '#', '#', '#' }
            };
        }

        public ChessProblemState(char[,] board)
        {
            this.chessboard = board;
        }

        public char[,] GetState
        {
            get { return (char[,])this.chessboard.Clone(); }
        }

        public override bool IsGoalState()
        {
            for (int i = 0; i < this.chessboard.GetLength(0); i++)
            {
                for (int u = 0; u < this.chessboard.GetLength(1); u++)
                {
                    if (this.chessboard[i, u] != GOAL[i, u]) return false;
                }
            }
            return true;
        }

        public override bool IsState()
        {
            int yLength = this.chessboard.GetLength(0);
            int xLength = this.chessboard.GetLength(1);
            for (int i = 0; i < xLength; i++)
            {
                if (chessboard[0,i] != '#' || chessboard[yLength - 1, i] != '#') { return false; }
            }

            for (int i = 1; i < yLength - 1; i++)
            {
                if (chessboard[i, 0] != '#' || chessboard[i, xLength - 1] != '#') { return false; }
            }

            return true;
        }

        public bool IsOperator(bool t, CanActions u)
        {
            throw new NotImplementedException();
        }

        public bool ApplyOperator(bool t, CanActions u)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.chessboard.GetLength(0); i++)
            {
                for (int u = 0; u < this.chessboard.GetLength(1); u++)
                {
                    sb.Append(this.chessboard[i, u]);
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
