using System;

namespace BinaryOperator.Core
{
    public class Semigroup<T, TDest> : Groupoid<T, TDest>, IAssociable<T>
    {
        public new static Semigroup<T, T> From(Func<T, T, T> operatorExpression) =>
             new Semigroup<T, T>(operatorExpression, t => t);
        internal Semigroup(Func<T, T, T> operatorExpression, Func<T, TDest> functor)
            : base(operatorExpression, functor)
        {
        }
        public Monoid<T, TDest> ToMonoid(T identity) => new Monoid<T, TDest>(Operator, Functor, identity);
        private bool IsValid(T a, T b, T c) => Operator(Operator(a , b) , c).Equals(Operator(a , Operator(b , c)));

        public new Semigroup<T, TNextDest> Map<TNextDest>(Func<TDest, TNextDest> mapper) =>
            new Semigroup<T, TNextDest>(Operator, t => mapper(Functor(t)));
    }
}