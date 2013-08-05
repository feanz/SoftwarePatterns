The builder pattern is used when object construction becomes complex. 

It deals with the issue of:
1. Too many parameters
2. When constructor parameters become order dependent
3. Construct different objects (we need to separate data and logic) 

The pattern separates the construction of a complex object form its representation so the same construction process can create different representations. 


Examples:  
In our example we have a class the employee which constructor is getting to big.  We refractor this so that we expose its data as public properties.  This now mean we have no control over how our object is built.
So give us this control back we produce a Employee director this class knows what is the process for building an object but should not care about the data required to generate any concrete instance of the employee class.
The maker takes a employee builder this is an abstract class the we need to implement for any given employee type.  These clases are concerned with what data is needed for their given type but not the process logic.  