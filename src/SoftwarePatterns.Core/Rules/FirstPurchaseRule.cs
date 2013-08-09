using System;

namespace SoftwarePatterns.Core.Rules
{
	public class FirstPurchaseRule : IDiscountRule
	{
		public decimal CalculateCustomerDiscount(DiscountCustomer customer)
		{
			if (customer.DateOfFirstPurchase.HasValue && customer.DateOfFirstPurchase.Value == DateTime.Today)
				return 0.05m;
			return 0;
		}
	}
}