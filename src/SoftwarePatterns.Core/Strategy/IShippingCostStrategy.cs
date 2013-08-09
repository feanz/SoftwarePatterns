namespace SoftwarePatterns.Core.Strategy
{
	public interface IShippingCostStrategy
	{
		bool CanCaclculate(ShippingOrder shippingOrder);
		void CalculateCost(ShippingOrder shippingOrder);
	}
}