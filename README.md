# BinaryOperator
A practice of abstract algebra on C# with a convenient way on C# .NET platform.
Great thanks to 
> https://antimatroid.wordpress.com/2012/04/01/abstract-algebra-in-c/
who inspired me on this repository.

## Introduction
Imagine you have to implement a new class called `Even`, which should behave always the same functionality of `int`: adding, substracting. But only with the even numbers. It should not receive any odd number in its calculation. Then it can be written using `implicit` approach:
```c#
public static implicit operator Even(int a)
{
  if (a % 2 == 0)
    return new Even(a);
  else
    throw new ArgumentOutOfRangeException();
}
```
However, there is still many behaviour that does not get from integer it self. Then we try using inherit approach:
```c#
public class Even: int
{  
}
```
But wait... `int` is `sealed` so it cannot be inherited by any class! Even though it is a homomorphism between `int` and `even` but we still cannot find a simple way to use them.
This repository is aim for solving these problems!

## Usage
To clearify, `G` here represent for any of `Groupoid` / `Semigroup` / `Monoid` / `Group` / `AbelianGroup`
### Create
```c#
var addingIntegerGroupoid = Groupoid.From((int a, int b) => a + b);
```
Represent a Groupoid with + as binary operator, closed inside integer.
```c#
var addingIntegerSemigroup = Semigroup.From((int a, int b) => a + b);
```
Same as above, but should be associable.
```c#
var addingIntegerMonoid = Monoid.From((int a, int b) => a + b, 0);
```
Same as above, but with an identity 0.
```c#
var addingIntegerGroup = Group.From((int a, int b) => a + b, 0, (int a) => -a);
```
Same as above, but assign with an inverse function `f(a) = -a` so such that `a + f(a) = identity`.
```c#
var addingIntegerAbelianGroup = AbelianGroup.From((int a, int b) => a + b, 0, (int a) => -a);
```
Same as above, but should be commutable.
### Mapping
```c#
addingIntegerGroup.Map(integer => integer * 2);
```
G(+) is multiplied by 2. It is no longer closable in N but 2N.
### Upgrade
Every G is extending the basis G class. Eg. A group should already be considered as a groupoid.
To upgrade, you can use:
```c#
var addingIntegerAbelianGroup = 
  Groupoid.From((int a, int b) => a + b)
    .ToSemigroup()
    .ToMonoid(0)
    .ToGroup((int a) => -a)
    .ToAbelianGroup();
// valid
```
### Fluent form
All G support fluent form so you can understand flow by flow easily.
```c#
Groupoid.From((int a, int b) => a + b)
  .Map(inta => inta * 2)
  .Map(even => even as double)
  .Map(decimal =>decimal.ToString());
// will create an integer groupoid with Functor that double, set as decimal number and set as string.
```

## Future plan / TODO
1. Validation of a groupoid / semi-group / monoid / group / abelian group
2. Group Element type
3. No plan on maintaining this repository. Just for fun.
## Contact
Create issue at this repository
