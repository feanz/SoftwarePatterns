using System;

namespace SoftwarePatterns.Core.Command
{
	public class ShipOrderCommad : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Ship the order");
		}
	}
}