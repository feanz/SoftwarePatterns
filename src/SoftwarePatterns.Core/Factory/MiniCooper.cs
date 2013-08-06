using System;

namespace SoftwarePatterns.Core.Factory
{
	public class MiniCooper : IAuto
	{
		public void TurnOn()
		{
			Console.WriteLine("Mini cooper on");
		}

		public void TurnOff()
		{
			Console.WriteLine("Mini cooper off");
		}
	}
}