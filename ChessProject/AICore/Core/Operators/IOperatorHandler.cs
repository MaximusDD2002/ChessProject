using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    interface IOperatorHandler<T>
    {
        bool IsOperator(T t);
        bool ApplyOperator(T t);
    }

    interface IOperatorHandler<T, U>
    {
        bool IsOperator(T t, U u);
        bool ApplyOperator(T t, U u);
    }

    interface IOperatorHandler<T, U, V>
    {
        bool IsOperator(T t, U u, V v);
        bool ApplyOperator(T t, U u, V v);
    }

    interface IOperatorHandler<T, U, V, W>
    {
        bool IsOperator(T t, U u, V v, W w);
        bool ApplyOperator(T t, U u, V v, W w);
    }

    interface IOperatorHandler<T, U, V, W, X>
    {
        bool IsOperator(T t, U u, V v, W w, X x);
        bool ApplyOperator(T t, U u, V v, W w, X x);
    }

    interface IOperatorHandler<T, U, V, W, X, Y>
    {
        bool IsOperator(T t, U u, V v, W w, X x, Y y);
        bool ApplyOperator(T t, U u, V v, W w, X x, Y y);
    }

    interface IOperatorHandler<T, U, V, W, X, Y, Z>
    {
        bool IsOperator(T t, U u, V v, W w, X x, Y y, Z z);
        bool ApplyOperator(T t, U u, V v, W w, X x, Y y, Z z);
    }
}
