Define:
	Without violating encapsulation, capture and externalize an object's internal state allowing the object to be restored to this state later.	Yes	No	N/A

Usage:
	For rollback undo 
	Provide access to object internal state without violating encapsulation.

Structure:
	In the memento pattern the is the originator the object we wish to track the memento the object that holds its state and the caretaker that maintains the memento.

Example:
	A simple wpf drawing application with undo feature. 