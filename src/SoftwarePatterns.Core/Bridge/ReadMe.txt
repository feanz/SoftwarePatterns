The bridge pattern decouples and abstraction from its implementation so the two can vary independently.  

The bridge connect two implementation. 

Example: 
We have a abstraction the abstract class Manuscript refined versions of that abstraction in the book, faq and termpaper.  The manuscript uses an implementer the IFormatter to provide an implementation of formatting that is 
decoupled from the manuscript type.  We then have multiple concrete implementations of the formatter. 

This allows us to have multiple document types and multiple types of formatting without having to build out a complex implementation hierarchy.  
We have bridged our two abstractions the manuscript abstract and the formatting abstraction. 
 
