using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public abstract class AbstractState : ICloneable
    {
        public abstract bool IsState();
        public abstract bool IsGoalState();

        public virtual object Clone() { return this.MemberwiseClone(); }

        public override bool Equals(object obj) { return false; }
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
