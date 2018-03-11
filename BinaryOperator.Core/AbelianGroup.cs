using System;

namespace BinaryOperator.Core
{
        public class AbelianGroup<T> : Group<T>, ICommutable<T>
    {
        internal AbelianGroup(Func<T, T, T> operatorExpression, T identity, Func<T, T> inverseFunction)
            : base(operatorExpression, identity, inverseFunction)
        {
        }
        public new static AbelianGroup<T> From(Func<T, T, T> operatorExpression, T identity, Func<T, T> inverseFunction) =>
            new AbelianGroup<T>(operatorExpression, identity, inverseFunction);
        private bool IsValid(T a, T b) => Operator(a, b).Equals(Operator(b, a));
    }
}