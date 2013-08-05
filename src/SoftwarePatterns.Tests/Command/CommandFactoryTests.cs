using SoftwarePatterns.Core.Command;
using Xunit;

namespace SoftwarePatterns.Tests.Command
{
	public class CommandFactoryTests
	{
		public class MakeCommandMethod
		{
			[Fact]
			public void ShouldReturnNotFoundCommandWhenCommandNameWrong()
			{
				var factory = new CommandFactory();
				var command = factory.MakeCommand("Barry");

				Assert.Equal(typeof(NotFoundCommand), command.GetType());
			}

			[Fact]
			public void ShouldReturnCommandWhenCorrectNameProvided()
			{
				var factory = new CommandFactory();
				var command = factory.MakeCommand("UpdateQuantity");

				Assert.Equal(typeof(UpdateQuantityCommand), command.GetType());
			}
		}
	}
}