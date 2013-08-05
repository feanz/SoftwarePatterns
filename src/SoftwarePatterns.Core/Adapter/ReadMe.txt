The adapter pattern is useful when some library or code does not implement an interface you require. 
The adapter wraps (this pattern is some times know as the adapter pattern) the lib or code and allows you to use a single common interface. 
The adapter converts the interface of one class to the interface of another. 
Adapters can help maintain the open closed principle.
A very common example of this in .net is ADO IDataAdapter which has Odbc, OleDB, SQl there is a common interface but different adapters form different persistence tech.

Example:
The example code in the projects adapters a lib code data renderer that needs to be used to display data to the user.  It takes the IDbDataAdapter filling a dataset and then rendering this to the screen. 
We have a pattern renderer class that expects an IEnumerable<Pattern> and returns string.  We create an IDataPatternRendererAdapter that takes the IEnumerable and converts it uses the DataRenderer to produce the output. 
This involves creating an IEnumerableDataAdapter that implements the IDbDataAdapter interface and implements the fill method so that for any IEnumerable<T> it can return a filled dataset. 




