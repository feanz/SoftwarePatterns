Define:
A proxy, in its most general form, is a class functioning as an interface to something else. The proxy could interface to anything: a network connection, 
a large object in memory, a file, or some other resource that is expensive or impossible to duplicate.

Usage:
A remote proxy acts as a local representative of a remote object and abstracts away the details of the communication with the remote object.
A virtual proxy creates expensive objects on demand.
A protection  proxy can be used to control access to the object, based on authorisation rules. 

Examples:
We have already seen examples of the proxy object in the lazy loading pattern where objects or properties are loaded only when requested by the client

Consequences
Proxy objects must be kept up to date with the real object either manually or via code generation (this is common in ORM or remote proxy in WCF)
Client code may make incorrect assumptions about the behaviour of real objects
