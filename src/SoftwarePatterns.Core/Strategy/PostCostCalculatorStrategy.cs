namespace SoftwarePatterns.Core.Strategy
{
	public class PostCostCalculatorStrategy : IShippingCostStrategy
	{
		public bool CanCaclculate(ShippingOrder shippingOrder)
		{
			return shippingOrder.Shipping == "UPS";
		}

		public void CalculateCost(ShippingOrder shippingOrder)
		{
			shippingOrder.Cost = 4.3m;
		}
	}
}