using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public interface IProxyOperator
    {
        int GetNrOfOperators();
        bool ProxyOperator(int index);
    }
}
