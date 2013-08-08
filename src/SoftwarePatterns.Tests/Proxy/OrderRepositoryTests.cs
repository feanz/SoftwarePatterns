using SoftwarePatterns.Core.Proxy;
using Xunit;

namespace SoftwarePatterns.Tests.Proxy
{
	public class OrderRepositoryTests
	{
		public class GetByIdMethod
		{
			[Fact]
			public void ShouldOnlyFetchOnce()
			{
				var repository = new OrderCacheRepository();
				var order1 = repository.GetById(1);
				var order2 = repository.GetById(1);
				var order3 = repository.GetById(1);

				Assert.Equal(1, repository.OrderFetched);
			}
		}
	}
}