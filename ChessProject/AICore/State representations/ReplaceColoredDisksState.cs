using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class ReplaceColoredDisksState : AbstractState, IOperatorHandler<int, int>
    {
        private static char[,] goalState = new char[,]
        {
            {'r', 'r', 'r', 'b', 'b'},
            {'r', 'r', 'r', 'b', 'b'},
            {'r', 'r', 'w', 'b', 'b'},
            {'r', 'r', 'b', 'b', 'b'},
            {'r', 'r', 'b', 'b', 'b'}
        };

        public ReplaceColoredDisksState()
        {
            disks = new char[,]
            {
                {'b', 'b', 'b', 'r', 'r'},
                {'b', 'b', 'b', 'r', 'r'},
                {'b', 'b', 'w', 'r', 'r'},
                {'b', 'b', 'r', 'r', 'r'},
                {'b', 'b', 'r', 'r', 'r'}
            };
        }

        private char[,] disks;
        public char[,] Disks
        {
            get
            {
                char[,] temp = new char[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        temp[i, j] = this.disks[i, j];
                    }
                }
                return temp;
            }
        }

        public override bool IsState()
        {
            int countBlue = 0, countRed = 0, countWhite = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (disks[i, j])
                    {
                        case 'b': countBlue++; break;
                        case 'r': countRed++; break;
                        case 'w': countWhite++; break;
                        default: break;
                    }
                }
            }
            return countBlue == 12 && countRed == 12 && countWhite == 1;
        }

        public override bool IsGoalState()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.disks[i, j] != goalState[i, j])
                        return false;
                }
            }
            return true;
        }

        private bool CanReplaceDisk(int x, int y)
        {
            return false;
        }
        private void ReplaceDisk(int x, int y)
        {
            if (!CanReplaceDisk(x, y))
                return;

            //replace
        }

        public bool IsOperator(int x, int y)
        {
            if (x < 0 || x > 4) return false;
            if (y < 0 || y > 4) return false;
            if (this.disks[x, y] == 'w') return false;

            return true;
        }

        public bool ApplyOperator(int x, int y)
        {
            if (!IsOperator(x, y))
                return false;

            ReplaceColoredDisksState clone = (ReplaceColoredDisksState)Clone();

            ReplaceDisk(x, y);

            if (IsState())
                return true;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    this.disks[i, j] = clone.disks[i, j];
                }
            }

            return false;
        }

        public override object Clone()
        {
            ReplaceColoredDisksState clone = new ReplaceColoredDisksState();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    clone.disks[i, j] = this.disks[i, j];
                }
            }
            return clone;
        }
    }
}
