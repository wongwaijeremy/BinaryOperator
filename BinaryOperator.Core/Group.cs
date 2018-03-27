using System;

namespace BinaryOperator.Core
{
    public class Group<T, TDest> : Monoid<T, TDest>, IInverse<T>
    {
        internal Group(Func<T, T, T> operatorExpression, Func<T, TDest> functor, T identity, Func<T, T> inverseFunction)
            : base(operatorExpression, functor, identity)
        {
            InverseFunction = inverseFunction;
        }
        public static Group<T, T> From(Func<T, T, T> operatorExpression, T identity, Func<T, T> inverseFunction) =>
            new Group<T, T>(operatorExpression, t => t, identity, inverseFunction);

        public Func<T, T> InverseFunction { get; }

        public T Inverse(T t) => InverseFunction(t);
        public AbelianGroup<T, TDest> ToAbelianGroup() =>
            new AbelianGroup<T, TDest>(Operator, Functor, Identity, InverseFunction);

        public new Group<T, TNextDest> Map<TNextDest>(Func<TDest, TNextDest> mapper) =>
            new Group<T, TNextDest>(Operator, t => mapper(Functor(t)), Identity, InverseFunction);
    }
}
