using System;

namespace SoftwarePatterns.Core.Factory
{
	public class NullAuto : IAuto
	{
		public void TurnOn()
		{
			Console.WriteLine("Car not found");
		}

		public void TurnOff()
		{
			Console.WriteLine("Car not found");
		}
	}
}