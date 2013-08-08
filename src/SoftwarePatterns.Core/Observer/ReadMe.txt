Define: 
The observer pattern is a software design pattern in which an object, called the subject, maintains a list of its dependents,
 called observers, and notifies them automatically of any state changes, usually by calling one of their methods. 

Applications:
When one object is dependent on another object
When changing one object requires a change to many others
When changes to an object should allow notification to others without any knowledge of them

Implementations .net 
Simple publisher subscriber 
	Observers subscribe to a subject class; when changes happen to this class the subject send update notifications to its subscribers
Events and delegates 
	Built in language feature to support this where the subject can raise events and observers can add event handler call back to the subjects event. 
IOberver<T>