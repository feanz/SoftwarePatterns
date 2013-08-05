using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwarePatterns.Core.Command
{
	public interface ICommandFactory
	{
		ICommand MakeCommand(string name);
		IEnumerable<Type> AvailableCommand { get; }
	}
}