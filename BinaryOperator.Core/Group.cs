using System;

namespace BinaryOperator.Core
{
    //https://antimatroid.wordpress.com/2012/04/01/abstract-algebra-in-c/
    public class Groupoid<T> : IClosable<T>
        where T: class
    {
        public Func<T, T, T> Operator{ get; private set; }
        public static Groupoid<T> From(Func<T, T, T> operatorExpression)
        {
            return new Groupoid<T>(operatorExpression);
        }
        internal Groupoid(Func<T, T, T> operatorExpression)
        {
            Operator = operatorExpression;
        }
        public T Operation(T a, T b) => Operator(a, b);    
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
