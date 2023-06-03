using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore.State_representations
{
    class ChessProblemState : AbstractState, IOperatorHandler<bool, CanActions>
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
        public override bool IsGoalState()
        {
            return (this.chessboard == GOAL);
        }

        public override bool IsState()
        {
            int xLength = this.chessboard.GetLength(0);
            int yLength = this.chessboard.GetLength(1);
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
    }
}
