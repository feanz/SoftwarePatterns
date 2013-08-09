Define:		
The singleton pattern is a design pattern that restricts the Instantiation of a class to one object. 	

"There can be only one" Sean Connery

Application:
	Used to ensure that we can share some global state in the application
	Useful if a global object is expensive to instantiate

Issues
	Difficult to test
	Breaks single responsibility principle a object should not be concerned with its own responsibility and that of ensuing their is only one instance of it.
	Possibly better to use an Ioc Container