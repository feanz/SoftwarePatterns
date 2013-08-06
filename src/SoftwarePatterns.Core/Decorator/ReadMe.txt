Define:

The decorator pattern allows behaviour to be added to an individual object, either statically or dynamically, without affecting the behaviour of other objects from the same class.

It allows us to add functionality to existing classes dynamically.
It provides an alternative to sub classes
It provides for greater design flexibility 
Supports the open closed principle. 
Can chain decorators
Can simplify code 

Usage Scenarios:

Legacy Systems
Add functionality to controls (especially UI controls)
Sealed classes

Structure:

There is always a components this is the base class we wish to add functionality to.  There can be many concrete implementations of this component.  The decorator is normally an interface that wraps the component object
the component becomes a property of the decorator. We can then have many implementations of this decorator.  These decorators can wrap any concrete implementations of the component and because they expose the property 
of the component they can also be wrapped by other  decorators.   

Example:

We created a simple application that wraps base pizza objects with topping decorators.  This may seem like a fairly trite example but consider if we tried to implement this with inheritance the complexity of the 
structure and the number of classes that would need to be involved. 

Possible issues:

Can increase amount of code ( possible increase in complexity if poorly implemented);
