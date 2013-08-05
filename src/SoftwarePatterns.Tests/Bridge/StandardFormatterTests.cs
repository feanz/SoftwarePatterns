using Ploeh.AutoFixture;
using SoftwarePatterns.Core.Bridge;
using Xunit;

namespace SoftwarePatterns.Tests.Bridge
{
	public class StandardFormatterTests
	{
		public class FormatMethod
		{
			[Fact]
			public void ShouldOutputExpectedFormat()
			{
				var fixture = new Fixture();

				var sut = fixture.Create<StandardFormatter>();

				var result = sut.Format("Key","Value");

				Assert.Equal("Key: Value", result);
			}
		}
	}
}