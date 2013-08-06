using System;

namespace SoftwarePatterns.Core.Factory
{
	public class Bmw : IAuto
	{
		public void TurnOn()
		{
			Console.WriteLine("Bmw 218i on");
		}

		public void TurnOff()
		{
			Console.WriteLine("Bmw 218i off");
		}
	}
}