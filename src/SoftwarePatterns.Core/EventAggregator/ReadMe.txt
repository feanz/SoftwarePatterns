Define:

An Event Aggregator acts as a single source of events for many objects. It registers for all the events of the many objects allowing clients to register with just the aggregator.

Traits:

Simplify event registration
Reduce coupling between publisher and subscriber
Reduce friction for introducing new events
Reduce memory management issues related to events (in .net the subscriber must hold a reference to the publisher, also helps us deal with the issue of subscribers not unsubscribing)

Applications:

Building composite application on client side
Complex user interface
Many publishers and subscribers
You have many events
New events are added frequently 

Example:

A simple order system with three events ordercreated orderselecte and ordersaved.  These events are just object we have not type restrictions.  Two subscribers a logger and a viewmodel listen for events and a simple client obejct 
publishes events. 

A simple event aggregator keeps a dictionary of events and an associated list of weak references to them. 
