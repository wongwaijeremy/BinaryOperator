using System;

namespace BinaryOperator.Core
{
        public class AbelianGroup<T, TDest> : Group<T, TDest>, ICommutable<T>
    {
        internal AbelianGroup(Func<T, T, T> operatorExpression, Func<T, TDest> functor, T identity, Func<T, T> inverseFunction)
            : base(operatorExpression, functor, identity, inverseFunction)
        {
        }
        public new static AbelianGroup<T, T> From(Func<T, T, T> operatorExpression, T identity, Func<T, T> inverseFunction) =>
            new AbelianGroup<T, T>(operatorExpression, t => t, identity, inverseFunction);
        private bool IsValid(T a, T b) => Operator(a, b).Equals(Operator(b, a));

        public new AbelianGroup<T, TNextDest> Map<TNextDest>(Func<TDest, TNextDest> mapper) =>
            new AbelianGroup<T, TNextDest>(Operator, t => mapper(Functor(t)), Identity, InverseFunction);
    }
}