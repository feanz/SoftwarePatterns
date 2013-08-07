Define:
A flyweight is an object that minimizes memory use by sharing as much data as possible with other similar objects; it is a way to
use objects in large numbers when a simple repeated representation would use an unacceptable amount of memory.

Usage:
When you have a large number of similar objects and you can't store them all in memory

Application:
Groups of objects are replaced by fewer shared object when as much extrinsic state has been removed from the object (an properties that can be moved from the object and provided by the client)

We save on storage by:
Reducing instances 
Reducing amount on intrinsic state per object 
Changing extrinsic state to be computed rather that stored

Example:  
We have a simple windows forms app that draws tiles on a form with the standard ITile our tiles store a lot of state which means that for every tile we draw we need to hold a ref to that object.
Using the IFlyweightTile we pass in the state from the client and store shared tile objects in a factory reducing the number of objects to the number of types.
