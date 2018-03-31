using System;
using System.Linq.Expressions;

namespace BinaryOperator.Core
{
    public class Groupoid<T, TDest> : IClosable<T>
    {
        public Func<T, T, T> Operator { get; }
        public Func<T, TDest> Functor { get; }
        public static Groupoid<T, T> From(Func<T, T, T> operatorExpression) =>
            new Groupoid<T, T>(operatorExpression, t => t);
        internal Groupoid(Func<T, T, T> operatorExpression, Func<T, TDest> functor)
        {
            Operator = operatorExpression;
            Functor = functor;
        }
        public T Operation(T a, T b) => Operator(a, b);

        public Semigroup<T, TDest> ToSemigroup() => new Semigroup<T, TDest>(Operator, Functor);

        public Groupoid<T, TDest> Select(Expression<Func<T, TDest>> mapper)
        {
            throw new NotImplementedException();
        }

        public Groupoid<T, TNextDest> Map<TNextDest>(Func<TDest, TNextDest> mapper) =>
            new Groupoid<T, TNextDest>(Operator, t => mapper(Functor(t)));

        public TDest Invoke(T domain) => Functor(domain);
    }
}