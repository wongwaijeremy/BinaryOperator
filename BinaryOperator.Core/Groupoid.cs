using System;
using System.Linq.Expressions;

namespace BinaryOperator.Core
{
    public class Groupoid<T> : IClosable<T>        
    {
        public Func<T, T, T> Operator { get; }
        public static Groupoid<T> From(Func<T, T, T> operatorExpression) => new Groupoid<T>(operatorExpression);
        internal Groupoid(Func<T, T, T> operatorExpression)
        {
            Operator = operatorExpression;
        }
        public T Operation(T a, T b) => Operator(a, b);

        public Semigroup<T> ToSemigroup() => Semigroup<T>.From(Operator);

        public Groupoid<TDest> Select<TDest>(Expression<Func<T, TDest>> mapper)
        {
            throw new NotImplementedException();
        }
    }
}