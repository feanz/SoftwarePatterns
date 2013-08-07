using System;
using SoftwarePatterns.Core.LazyLoad.LazyInitialisation;
using SoftwarePatterns.Core.LazyLoad.Proxy;
using Xunit;

namespace SoftwarePatterns.Tests.LazyLoad
{
	public class OrderTests
	{
		public class PrintMethod
		{
			[Fact]
			public void PrintWithBadOrder()
			{
				var order = new OrderBad();

				Assert.Throws<NullReferenceException>(() => order.Print());
			}

			[Fact]
			public void PrintWithGoodOrder()
			{
				var order = new OrderGood();

				var actual = order.Print();

				Assert.Contains("Customer", actual);
			}

			[Fact]
			public void PrintWithLazyOrder()
			{
				var order = new OrderLazy();

				var actual = order.Print();

				Assert.Contains("Customer", actual);
			}

			[Fact]
			public void CreateProxyOrder()
			{
				var factory = new OrderFactory();

				var actual = factory.CreateOrder(1);

				Assert.Equal(1, actual.Id);
			}
		}

	}
}