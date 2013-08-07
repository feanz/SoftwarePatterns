Define:
Lazy loading is a design pattern commonly used in computer programming to defer initialization of an object until the point at which it is needed

Usage:
Working with objects that must be loaded from some persistent store
You want to avoid loading portions of the object stat that you many not need
You don't want the client code to know when additional state needs to be loaded


Variants:
Lazy initialisation, virtual proxy, value holder and ghost


value holders are not really need post .net as we now have lazy<t> objects 