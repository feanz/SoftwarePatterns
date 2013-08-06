Define:

Compose objects into tree structures to represent part whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

Example:

We have a small games sim where we have players and group.  During the game they win gold and we need to determine the split of gold. Individual players and groups can play and each get an
equal split of the gold, players within a group get an equal split of the groups gold.

Because the player type and group type implement the same IParty interface the client code can treat these object as if they where the same.  A groups members is an IParty as well which means we can have groups within groups
and this allows us to have a full tree structure. 
