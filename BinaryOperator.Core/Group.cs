using System;

namespace BinaryOperator.Core
{
    //https://antimatroid.wordpress.com/2012/04/01/abstract-algebra-in-c/
    public interface IGroupoid<T>
    {
        T Operation(T a, T b);
    }

    public interface ISemigroup<T> : IGroupoid<T>
    {        
    }

    public interface IMonoid<T> : ISemigroup<T>
    {
        T Identity {get;}
    }
    public interface IGroup<T> : IMonoid<T>
    {
        T Inverse(T t);
    }
    public interface IAbelianGroup<T> : IGroup<T>
    {        
    }
}
