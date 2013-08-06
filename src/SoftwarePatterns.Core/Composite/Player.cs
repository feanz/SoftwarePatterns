using System;

namespace SoftwarePatterns.Core.Composite
{
	public class Player : IParty
	{
		public string Name { get; set; }
		public int Gold { get; set; }

		public void Stats()
		{
			Console.WriteLine("{0}: has {1} gold.", Name, Gold);
		}
	}
}