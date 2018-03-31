# BinaryOperator
A practice of abstract algebra on C#

Great thanks to 
https://antimatroid.wordpress.com/2012/04/01/abstract-algebra-in-c/
who inspired me on this repository

#Intention
To Provide a convenient way for Math student / CS Student to experience Abstract Algebra practise on C# .NET platform.

#Usage
###Fluent form
```
Groupoid.From((int a, int b) => a + b)
  .Map(inta => inta * 2)
  .Map(even => even as double)
  .Map(decimal =>decimal.ToString());
// will create an integer groupoid with Functor that double, set as decimal number and set as string.
```
