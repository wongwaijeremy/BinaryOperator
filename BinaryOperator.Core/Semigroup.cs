using System;

namespace BinaryOperator.Core
{    
    public class Semigroup<T> : Groupoid<T>, IAssociable<T>
    {
        public new static Semigroup<T> From(Func<T, T, T> operatorExpression) => new Semigroup<T>(operatorExpression);
        internal Semigroup(Func<T, T, T> operatorExpression) : base(operatorExpression)
        {
        }
        public Monoid<T> ToMonoid(T identity) => Monoid<T>.From(Operator, identity);
        private bool IsValid(T a, T b, T c) => Operator(Operator(a , b) , c).Equals(Operator(a , Operator(b , c)));
    }
}