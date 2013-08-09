using System;

namespace SoftwarePatterns.Core.Strategy
{
	public class ShippingCostCalculatorService
	{
		private readonly IShippingCostStrategy _shippingCostStrategy;

		public ShippingCostCalculatorService()
		{
			
		}

		public ShippingCostCalculatorService(IShippingCostStrategy shippingCostStrategy)
		{
			_shippingCostStrategy = shippingCostStrategy;
		}

		public void CalculateShippingCost(ShippingOrder order)
		{
			_shippingCostStrategy.CalculateCost(order);
		}
		
		public void CalculateShippingCost(ShippingOrder order, IShippingCostStrategy shippingCostStrategy)
		{
			shippingCostStrategy.CalculateCost(order);
		}

		public decimal CalculateShippingCost(ShippingOrder order, Func<ShippingOrder, decimal> shippingCostStrategy)
		{
			return shippingCostStrategy.Invoke(order);
		}
	}
}