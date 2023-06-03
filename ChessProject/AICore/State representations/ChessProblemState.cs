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

        static char[,] GOAL = new char[,]
        {
            { '#', '#', '#', '#', '#' },
            { '#', '2', '2', '0', '#' },
            { '#', '3', '3', '1', '#' },
            { '#', '#', '#', '#', '#' }
        };
        public override bool IsGoalState()
        {
            return (this.chessboard == GOAL);
        }

        public override bool IsState()
        {
            throw new NotImplementedException();
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
