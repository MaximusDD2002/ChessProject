using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class HungryHorseman3Super : AbstractSuperState
    {
        public override int GetNrOfOperators()
        {
            return 8;
        }

        public override bool ApplyOperator(int index)
        {
            switch (index)
            {
                case 0: return HorseStep(2, 1);
                case 1: return HorseStep(2, -1);
                case 2: return HorseStep(-2, 1);
                case 3: return HorseStep(-2, -1);
                case 4: return HorseStep(1, 2);
                case 5: return HorseStep(1, -2);
                case 6: return HorseStep(-1, 2);
                case 7: return HorseStep(-1, -2);
                default: return false;
            }
        }

        private int x, y;

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }

        public HungryHorseman3Super() //Constructor set the start state
        {
            this.x = 0;
            this.y = 0;
        }

        public override bool IsState()
        {
            return 0 <= this.x && this.x <= 2 &&
                   0 <= this.y && this.y <= 2;
        }

        public override bool IsGoalState()
        {
            return this.x == 2 && this.y == 2;
        }

        private bool IsHorseStep(int dx, int dy)
        {
            return Math.Abs(dx) + Math.Abs(dy) == 3;
            //return dx * dy == 2 || dx * dy == -2;
            //return Math.Abs(dx * dy) == 2;
        }
        public bool HorseStep(int dx, int dy)
        {
            if (!IsHorseStep(dx, dy))
                return false;

            this.x += dx;
            this.y += dy;

            if (IsState())
                return true;

            this.x -= dx;
            this.y -= dy;
            return false;
        }
    }
}
