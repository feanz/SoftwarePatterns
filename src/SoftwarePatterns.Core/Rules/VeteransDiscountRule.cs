namespace SoftwarePatterns.Core.Rules
{
	public class VeteransDiscountRule : IDiscountRule
	{
		public decimal CalculateCustomerDiscount(DiscountCustomer customer)
		{
			return (customer.IsVeteran) ? 0.05m : 0;
		}
	}
}