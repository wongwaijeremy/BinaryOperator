using System;

namespace BinaryOperator.Core
{
    public class Monoid<T, TDest> : Semigroup<T, TDest>, IIdentity<T>
    {
        public T Identity { get; }
        internal Monoid(Func<T, T, T> operatorExpression, Func<T, TDest> functor, T identity)
            : base(operatorExpression, functor)
        {
            Identity = identity;
        }
        public static Monoid<T, T> From(Func<T, T, T> operatorExpression, T identity) =>
            new Monoid<T, T>(operatorExpression, t => t, identity);
        public Group<T, TDest> ToGroup(Func<T, T> inverseFunction) =>
            new Group<T, TDest>(Operator, Functor, Identity, inverseFunction);
        private bool IsValid(T a) => Operator(a, Identity).Equals(Operator(Identity, a));

        public new Monoid<T, TNextDest> Map<TNextDest>(Func<TDest, TNextDest> mapper) =>
            new Monoid<T, TNextDest>(Operator, t => mapper(Functor(t)), Identity);
    }
}