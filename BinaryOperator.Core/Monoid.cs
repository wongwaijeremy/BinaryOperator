using System;

namespace BinaryOperator.Core
{
    public class Monoid<T> : Semigroup<T>, IIdentity<T>
    {
        public T Identity {get;}
        internal Monoid(Func<T, T, T> operatorExpression, T identity) : base(operatorExpression)
        {
            Identity = identity;
        }
        public static Monoid<T> From(Func<T, T, T> operatorExpression, T identity) => new Monoid<T>(operatorExpression, identity);
        public Group<T> ToGroup(Func<T, T> inverseFunction) => Group<T>.From(Operator, Identity, inverseFunction);
        private bool IsValid(T a) => Operator(a, Identity).Equals(Operator(Identity, a));
    }
}