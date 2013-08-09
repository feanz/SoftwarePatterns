Define:
	In software engineering, the template method pattern is a behavioural design pattern that defines the program skeleton of an algorithm in a method, called template method, which defers some steps to subclasses. 

Intent:
	Encapsulate and enforce the workflow or process that is not variable 
	Allow subclasses to alter specific behaviour via concrete implementations
	Redefine one or more steps of an algorithm without altering its structure

Usage
	When two or more classes should follow the same common algorithm or workflow
	The workflow is invariant. Subclasses may refine certain steps, but may not change the overall structure
	Some workflow steps can be encapsulated in the base class with default implementations and only overridden if necessary allowing code reuse

Consequences:
	Algorithm steps must be known and relatively inflexible at the time the pattern is applied
	Relies on inheritance rather and composition, which can be a limitation (see strategy pattern for a composition based approach)
	Single inheritance makes it difficult to merge two child algorithms into one (see decorator patter for possible solution)