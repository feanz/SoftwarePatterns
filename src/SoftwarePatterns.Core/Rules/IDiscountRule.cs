namespace SoftwarePatterns.Core.Rules
{
	public interface IDiscountRule
	{
		decimal CalculateCustomerDiscount(DiscountCustomer customer);
	}
}