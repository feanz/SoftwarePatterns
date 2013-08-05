The chain of responsibility pattern decouples the sender of a message from the receiver.

Traits:
The sender is only aware of one receiver 
Each receiver is only aware of the next receiver
Receiver process the message or pass it on.
The sender does not know who received the message
The first receiver to handle the message terminates the chain
The order of the receivers matters


Example: Employee expenses

We use the chain of responsibility to handle an employee expense validation chain. 