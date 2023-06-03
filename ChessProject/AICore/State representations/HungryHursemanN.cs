using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class HungryHursemanN : AbstractState, IOperatorHandler<int, int>, IProxyOperator
    {
        public HungryHursemanN(int n)
        {
            this.n = n;
           
        }

        int x, y;
        int n;

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }
        public int N { get { return this.n; } }

        public override bool IsState()
        {
            return 0 <= this.x && this.x <= n - 1 &&
                   0 <= this.y && this.y <= n - 1;
        }

        public override bool IsGoalState()
        {
            return this.x == n - 1 && this.y == n - 1;
        }

        public bool IsOperator(int dx, int dy)
        {
            return Math.Abs(dx) + Math.Abs(dy) == 3;
        }

        public bool ApplyOperator(int dx, int dy)
        {
            if (!IsOperator(dx, dy))
                return false;

            this.x += dx;
            this.y += dy;

            if (IsState())
                return true;

            this.x -= dx;
            this.y -= dy;
            return false;
        }

        public int GetNrOfOperators()
        {
            return 8;
        }

        public bool ProxyOperator(int index)
        {
            switch (index)
            {
                case 0: return ApplyOperator(2, 1);
                case 1: return ApplyOperator(2, -1);
                case 2: return ApplyOperator(-2, 1);
                case 3: return ApplyOperator(-2, -1);
                case 4: return ApplyOperator(1, 2);
                case 5: return ApplyOperator(1, -2);
                case 6: return ApplyOperator(-1, 2);
                case 7: return ApplyOperator(-1, -2);
                default: return false;
            }
        }
    }
}
