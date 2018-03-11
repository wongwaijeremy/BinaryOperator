using System;

namespace BinaryOperator.Core
{    
    public class Group<T> : Monoid<T>, IInverse<T>
    {
        internal Group(Func<T, T, T> operatorExpression, T identity, Func<T, T> inverseFunction)
            : base(operatorExpression, identity)
        {
            InverseFunction = inverseFunction;
        }
        public static Group<T> From(Func<T, T, T> operatorExpression, T identity, Func<T, T> inverseFunction) =>
            new Group<T>(operatorExpression, identity, inverseFunction);

        public Func<T, T> InverseFunction { get; }

        public T Inverse(T t) => InverseFunction(t);
        public AbelianGroup<T> ToAbelianGroup() => AbelianGroup<T>.From(Operator, Identity, InverseFunction);
    }    
}
