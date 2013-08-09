Define:
	The service locator pattern is a design pattern used in software development to encapsulate the processes involved in obtaining a service with a strong abstraction layer. A service locator allows us to register 
	service constructors for given interfaces.

Usage:
	Abstract the application from the service that it uses.
	Change the service without recompilation
	Identify services through configuration


Issues:
	API usage issues: How do we now know what a classes dependencies are without complete reference to what service locator calls it makes. 
	Maintenance issue:  How do we know what services have been registered with the service locator we get no compile time checks for class dependencies
	Can make unit testing more difficult;
