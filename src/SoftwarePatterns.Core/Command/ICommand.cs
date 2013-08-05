using System;

namespace SoftwarePatterns.Core.Command
{
	public interface ICommand
	{
		void Execute();
	}

	public class NotFoundCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Command not found");
		}
	}
}