using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class MovingInNumberMatrixState: AbstractState, IOperatorHandler<Direction8>
    {        
        public MovingInNumberMatrixState()
        {
            this.x = 0;
            this.y = 0;
        }

        public static int[,] matrix = new int[,]{
            { 1, 5, 3, 4, 3, 6, 7, 1, 1, 6 },
            { 4, 4, 3, 4, 2, 6, 2, 6, 2, 5 },
            { 1, 3, 9, 4, 5, 2, 4, 2, 9, 5 },
            { 5, 2, 3, 5, 5, 6, 4, 6, 2, 4 },
            { 1, 3, 3, 2, 5, 6, 5, 2, 3, 2 },
            { 2, 5, 2, 5, 5, 6, 4, 8, 6, 1 },
            { 9, 2, 3, 6, 5, 6, 2, 2, 2, 0 },
        }; //We should write a static property for this, and change this to private

        private int x, y;
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public override bool IsState()
        {
            if (this.x >= 0 && this.x < matrix.GetLength(0) &&
                this.y >= 0 && this.y < matrix.GetLength(1))
                return true;

            return false;
        }

        public override bool IsGoalState()
        {
            return this.x == matrix.GetLength(0) - 1 &&
                   this.y == matrix.GetLength(1) - 1;
        }

        private void Move(Direction8 direction)
        {
            int dx = 0;
            int dy = 0;
            switch (direction)
            {
                case Direction8.Up: dx = -1; dy = 0; break;
                case Direction8.Down: dx = 1; dy = 0; break;
                case Direction8.Left: dx = 0; dy = -1; break;
                case Direction8.Right: dx = 0; dy = 1; break;
                case Direction8.UpLeft: dx = -1; dy = -1; break;
                case Direction8.UpRight: dx = -1; dy = 1; break;
                case Direction8.DownLeft: dx = 1; dy = -1; break;
                case Direction8.DownRight: dx = 1; dy = 1; break;
                default:
                    break;
            }
            int maxStep = matrix[x, y];
            for (int step = 0; step < maxStep; step++)
            {
                this.x += dx;
                this.y += dy;

                if (!IsState())
                {
                    this.x -= dx;
                    this.y -= dy;
                    break;
                }
            }
        }

        public bool IsOperator(Direction8 direction)
        {
            return true;
        }

        public bool ApplyOperator(Direction8 direction)
        {
            if (!IsOperator(direction))
                return false;

            int tempX = this.x;
            int tempY = this.y;

            Move(direction);

            if (IsState())
                return true;

            this.x = tempX;
            this.y = tempY;

            return false;
        }
    }
}
