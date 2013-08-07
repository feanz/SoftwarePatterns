using SoftwarePatterns.Core.Flyweight;
using Xunit;

namespace SoftwarePatterns.Tests.Flyweight
{
	public class TileFactoryTests
	{
		public class GetTileMethod
		{
			[Fact]
			public void ShouldOnlyCreateOneObjectForMultipleCalls()
			{
				var factory = new TileFactory();

				var result = factory.GetTile("ceramic");
				var result1 = factory.GetTile("ceramic");

				Assert.Equal(result, result1);
				Assert.Equal(1, CeramicFlyweightTile.ObjectCounter);
			}
		}
	}
}