using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SoftwarePatterns.Core.Command
{
	public class CommandFactory : ICommandFactory
	{
		private IEnumerable<Type> availableCommand;
		public string CommandName { get; private set; }
		public string Description { get; private set; }

		public ICommand MakeCommand(string name)
		{
			var commandType = FindRequestedCommand(name);

			if (commandType != null)
			{
				return (ICommand)Activator.CreateInstance(commandType,null);
			}
			return new NotFoundCommand();
		}

		private Type FindRequestedCommand(string name)
		{
			var command = AvailableCommand.FirstOrDefault(type => String.Equals(type.Name.Replace("Command", ""), name, StringComparison.InvariantCultureIgnoreCase));
			return command;
		}

		public IEnumerable<Type> AvailableCommand
		{
			get
			{
				return availableCommand ?? (availableCommand = GetAvailableCommands());
			}
		}

		private static IEnumerable<Type> GetAvailableCommands()
		{
			var list = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.GetInterfaces().Contains(typeof (ICommand)))
				.ToList();

			return list;
		}
	}
}