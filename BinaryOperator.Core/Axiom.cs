namespace BinaryOperator.Core
{
    //https://antimatroid.wordpress.com/2012/04/01/abstract-algebra-in-c/
    public interface IClosable<T>
    {
        T Operation(T a, T b);
    }
    public interface IAssociable<T>
    {
    }
    public interface ICommutable<T>
    {
    }
    public interface IIdentity<T>
    {
        T Identity { get; }
    }
    public interface IInverse<T>
    {
        T Inverse(T t);
    }
}