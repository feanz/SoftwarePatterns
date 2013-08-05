using System;

namespace SoftwarePatterns.Core.Command
{
	public class UpdateQuantityCommand : ICommand
	{
		public int NewQuantity { get; set; }

		private const int oldQuantity = 5;

		public void Execute()
		{
			//simulate updating db
			Console.WriteLine("Database updated");

			//simulate logging
			Console.WriteLine("LOG: Updated order quantity from {0} to {1}", oldQuantity, NewQuantity);
		}
	}
}