using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public abstract class AbstractSuperState : AbstractState
    {
        public abstract int GetNrOfOperators();
        public abstract bool ApplyOperator(int index);
    }
}
