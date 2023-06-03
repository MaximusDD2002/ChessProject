using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class SwitchColorsInStrangeFlagState : AbstractState, IOperatorHandler<int, int, Direction>
    {
        private char[,] cells;
        private char[,] goalState;

        public char[,] Cells
        {
            get
            {
                char[,] temp = new char[this.cells.GetLength(0), this.cells.GetLength(1)];
                for (int i = 0; i < this.cells.GetLength(0); i++)
                {
                    for (int j = 0; j < this.cells.GetLength(1); j++)
                    {
                        temp[i, j] = this.cells[i, j];
                    }
                }
                return temp;
            }
        }

        private SwitchColorsInStrangeFlagState(char[,] matrix)
        {
            this.cells = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    this.cells[i, j] = matrix[i, j];
                }
            }

            this.goalState = new char[,]{
                {'x', 'x', 'x', 'x' ,'x'},
                {'x', 'r', 'r', 'r', 'x'},
                {'x', 'x', 'w', 'x', 'x'},
                {'x', 'w', 'w', 'x', 'x'},
                {'x', 'x', 'w', 'x', 'x'},
                {'x', 'g', 'g', 'g', 'x'},
                {'x', 'x', 'x', 'x' ,'x'}
            };
        }
        public SwitchColorsInStrangeFlagState()
        {
            this.cells = new char[,]{
                {'x', 'x', 'x', 'x' ,'x'},
                {'x', 'g', 'g', 'g', 'x'},
                {'x', 'x', 'w', 'x', 'x'},
                {'x', 'w', 'w', 'x', 'x'},
                {'x', 'x', 'w', 'x', 'x'},
                {'x', 'r', 'r', 'r', 'x'},
                {'x', 'x', 'x', 'x' ,'x'}
            };

            this.goalState = new char[,]{
                {'x', 'x', 'x', 'x' ,'x'},
                {'x', 'r', 'r', 'r', 'x'},
                {'x', 'x', 'w', 'x', 'x'},
                {'x', 'w', 'w', 'x', 'x'},
                {'x', 'x', 'w', 'x', 'x'},
                {'x', 'g', 'g', 'g', 'x'},
                {'x', 'x', 'x', 'x' ,'x'}
            };
        }

        public override bool IsState()
        {
            if (this.cells[2, 1] != 'x' || this.cells[2, 3] != 'x' || this.cells[3, 3] != 'x' ||
                this.cells[4, 1] != 'x' || this.cells[4, 3] != 'x')
                return false;

            int countR = 0, countG = 0, countW = 0;
            for (int i = 1; i < this.cells.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < this.cells.GetLength(1) - 1; j++)
                {
                    switch (cells[i, j])
                    {
                        case 'r': countR++; break;
                        case 'g': countG++; break;
                        case 'w': countW++; break;
                        default: break;
                    }
                }
            }
            return countG == 3 && countR == 3 && countW == 4;
        }

        public override bool IsGoalState()
        {
            for (int i = 0; i < this.cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.cells.GetLength(1); j++)
                {
                    if (this.cells[i, j] != this.goalState[i, j])
                        return false;
                }
            }
            return true;
        }

        public override object Clone()
        {
            SwitchColorsInStrangeFlagState clone = new SwitchColorsInStrangeFlagState(this.cells);
            return clone;
        }

        private char Neighbour(int i, int j, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return this.cells[i - 1, j];
                case Direction.Down: return this.cells[i + 1, j];
                case Direction.Left: return this.cells[i, j - 1];
                case Direction.Right: return this.cells[i, j + 1];
                default: throw new ArgumentOutOfRangeException();
            }
        }
        public bool IsOperator(int i, int j, Direction direction)
        {
            if (i < 1 || i > 5 || j < 1 || j > 3)
                return false;

            if (this.cells[i, j] == 'x')
                return false;

            char neighbour = Neighbour(i, j, direction);
            return neighbour == 'w';
        }
        private void Switch(int i, int j, Direction direction)
        {
            char neighbour = Neighbour(i, j, direction);
            char temp = this.cells[i, j];
            this.cells[i, j] = neighbour;
            switch (direction)
            {
                case Direction.Up: this.cells[i - 1, j] = temp; break;
                case Direction.Down: this.cells[i + 1, j] = temp; break;
                case Direction.Left: this.cells[i, j - 1] = temp; break;
                case Direction.Right: this.cells[i, j + 1] = temp; break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        public bool ApplyOperator(int i, int j, Direction direction)
        {
            if (!IsOperator(i, j, direction)) 
                return false;

            SwitchColorsInStrangeFlagState clone = (SwitchColorsInStrangeFlagState)this.Clone();

            Switch(i, j, direction);

            if (IsState())
                 return true;

            //this.cells = clone.Cells;
            for (int k = 0; k < clone.Cells.GetLength(0); k++)
            {
                for (int l = 0; l < clone.Cells.GetLength(1); l++)
                {
                    this.cells[k, l] = clone.Cells[i, j];
                }
            }

            return false;
        }       
    }
}
