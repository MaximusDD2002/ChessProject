using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class HungryHorseman3 : AbstractState
    {
        private int x, y;

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }

        public HungryHorseman3() //Constructor set the start state
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
