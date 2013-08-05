In the command pattern we use an  object to represent and encapsulate all the information needed to call a method at a later time.  

We have a client which executes commands these commands useually have a receiver object that the command call to do the actual work.  There is also an optional invoker object that the command can be 
passed to in order to perform command book keeping. 

Traits:
The command must be completely self contained it should never get any arguments from the client
Excellent for maintaining open closed principle

Usage scenario:

Logging 
Undo
Validation
