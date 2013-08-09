using System.Collections.Generic;

namespace SoftwarePatterns.Core.Visitor
{
	public class Person
	{
		public List<IAsset> Assets = new List<IAsset>();
	}
}