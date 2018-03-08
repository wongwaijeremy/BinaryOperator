using System;

namespace BinaryOperator.Core
{
    //https://antimatroid.wordpress.com/2012/04/01/abstract-algebra-in-c/
    public class Groupoid<T> : IClosable<T>
        where T: class
    {
        public Func<T, T, T> Operator { get; private set; }
        public static Groupoid<T> From(Func<T, T, T> operatorExpression) => new Groupoid<T>(operatorExpression);
        internal Groupoid(Func<T, T, T> operatorExpression)
        {
            Operator = operatorExpression;
        }
        public T Operation(T a, T b) => Operator(a, b);

        public Semigroup<T> ToSemigroup() => Semigroup<T>.From(Operator);
    }

    public class Semigroup<T> : Groupoid<T>, IAssociable<T>
        where T: class
    {
        public new static Semigroup<T> From(Func<T, T, T> operatorExpression) => new Semigroup<T>(operatorExpression);
        internal Semigroup(Func<T, T, T> operatorExpression) : base(operatorExpression)
        {
        }
        public Monoid<T> ToMonoid(T identity) => Monoid<T>.From(Operator, identity);
        private bool IsValid(T a, T b, T c) => Operator(Operator(a , b) , c).Equals(Operator(a , Operator(b , c)));
    }

    public class Monoid<T> : Semigroup<T>, IIdentity<T>
        where T: class
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
    public class Group<T> : Monoid<T>, IInverse<T>
        where T: class
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
    }
    public interface IAbelianGroup<T> : IGroup<T>
    {        
    }
}
