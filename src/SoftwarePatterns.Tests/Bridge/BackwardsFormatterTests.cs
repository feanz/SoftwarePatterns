using Ploeh.AutoFixture;
using SoftwarePatterns.Core.Bridge;
using Xunit;

namespace SoftwarePatterns.Tests.Bridge
{
	public class BackwardsFormatterTests
	{
		public class FormatMethod
		{
			[Fact]
			public void ShouldOutputExpectedFormat()
			{
				var fixture = new Fixture();

				var sut = fixture.Create<BackwardsFormatter>();

				var result = sut.Format("Key", "Value");

				Assert.Equal("Key: eulaV", result);
			}
		}
	}
}