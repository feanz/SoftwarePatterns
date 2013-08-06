using SoftwarePatterns.Core.Factory;
using Xunit;

namespace SoftwarePatterns.Tests.Factory
{
	public class AutoFactoryTests
	{
		public class CreateMethod
		{
			[Fact]
			public void ShouldReturnNullObjectForUnknownCar()
			{
				var sut = new AutoFactory();

				var actual = sut.Create("Ball bag");

				Assert.IsAssignableFrom<NullAuto>(actual);
			}
		}
	}
}