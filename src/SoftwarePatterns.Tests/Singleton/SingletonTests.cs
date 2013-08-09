using Xunit;

namespace SoftwarePatterns.Tests.Singleton
{
	public class SingletonTests
	{
		[Fact]
		public void ThereCanBeOnlyOne()
		{
			var one = Core.Singleton.Singleton.Instance;
			var two = Core.Singleton.Singleton.Instance;

			Assert.True(ReferenceEquals(one, two));
		}
	}
}