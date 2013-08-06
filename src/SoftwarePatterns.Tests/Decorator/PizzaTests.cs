using System.Runtime;
using SoftwarePatterns.Core.Decorator;
using Xunit;

namespace SoftwarePatterns.Tests.Decorator
{
	public class PizzaTests
	{
		public class CalculateCostsMethod
		{
			[Fact]
			public void ShouldAddBaseCostPlusDecorators()
			{
				Pizza pizza = new LargePizza();
				var firstAmount = pizza.CalculateCost();
				pizza = new Ham(pizza);

				Assert.Equal(firstAmount + 1, pizza.CalculateCost());
			}
		}
	}
}