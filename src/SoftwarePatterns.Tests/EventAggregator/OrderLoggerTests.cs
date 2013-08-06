using Moq;
using SoftwarePatterns.Core.EventAggregator;
using Xunit;

namespace SoftwarePatterns.Tests.EventAggregator
{
	public class OrderLoggerTests
	{
		[Fact]
		public void ShouldSubscribeToOrderCreatedEvent()
		{
			var ea = new Mock<IEventAggregator>();
			ea.Setup(aggregator => aggregator.Subscribe(It.IsAny<OrderLogger>())).Verifiable();
			
			var logger = new OrderLogger(ea.Object);

			ea.VerifyAll();
		}

		[Fact]
		public void ShouldImplementISubscribeOrderCreated()
		{
			var ea = new Mock<IEventAggregator>();
			var logger = new OrderLogger(ea.Object);

			Assert.IsAssignableFrom<ISubscriber<OrderCreated>>(logger);
		}
	}
}