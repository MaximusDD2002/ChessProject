using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class DieHard3State : AbstractState, IOperatorHandler<bool, CanActions>
    {
        int can3, can5;
        public int Can3 { get { return can3; } }
        public int Can5 { get { return can5; } }

        public DieHard3State()
        {
            can3 = 0;
            can5 = 0;
        }

        public override bool IsState()
        {
            return can3 >= 0 && can3 <= 3 &&
                   can5 >= 0 && can5 <= 5;
        }

        public override bool IsGoalState()
        {
            return can5 == 4;
        }

        public bool IsOperator(bool fromCan3, CanActions action)
        {
            switch (action)
            {
                case CanActions.Fill:
                    if (fromCan3 && can3 == 3) return false;
                    if (!fromCan3 && can5 == 5) return false;
                    return true;
                case CanActions.PourOut:
                    if (fromCan3 && can3 == 0) return false;
                    if (!fromCan3 && can5 == 0) return false;
                    return true;
                case CanActions.PourInto:
                    if (fromCan3 && (can3 == 0 || can5 == 5)) return false;
                    if (!fromCan3 && (can5 == 0 || can3 == 3)) return false;
                    return true;
                default: return false;
            }
        }

        public bool ApplyOperator(bool fromCan3, CanActions action)
        {
            if (!IsOperator(fromCan3, action))
                return false;

            DieHard3State clone = (DieHard3State)this.Clone();

            switch (action)
            {
                case CanActions.Fill:
                    if (fromCan3) can3 = 3;
                    else can5 = 5;
                    break;
                case CanActions.PourOut:
                    if (fromCan3) can3 = 0;
                    else can5 = 0;
                    break;
                case CanActions.PourInto:
                    if (fromCan3)
                    {
                        int targetGallonEmptySpace = 5 - can5;
                        int canBePoured = Math.Min(targetGallonEmptySpace, can3);
                        can5 += canBePoured;
                        can3 -= canBePoured;
                    }
                    else
                    {
                        int targetGallonEmptySpace = 3 - can3;
                        int canBePoured = Math.Min(targetGallonEmptySpace, can5);
                        can3 += targetGallonEmptySpace;
                        can5 -= targetGallonEmptySpace;
                    }
                    break;
                default:
                    break;
            }

            if (IsState())
                return true;

            this.can3 = clone.can3;
            this.can5 = clone.can5;

            return false;
        }

        public override string ToString()
        {
            return string.Format("gallon5: {0} - gallon3: {1}", can5, can3);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is DieHard3State)) return false;
            DieHard3State other = (DieHard3State)obj;
            return this.can3 == other.can3 && this.can5 == other.can5;
        }
    }
}
