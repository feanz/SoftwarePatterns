using System;

namespace SoftwarePatterns.Core.Rules
{
	public class LoyalCustomerDiscount : IDiscountRule
	{
		private readonly int _yearsCustomer;
		private readonly decimal _discount;

		public LoyalCustomerDiscount(int yearsCustomer, decimal discount)
		{
			_yearsCustomer = yearsCustomer;
			_discount = discount;
		}

		public decimal CalculateCustomerDiscount(DiscountCustomer customer)
		{
			var discount = 0m;
			if (customer.DateOfFirstPurchase != null &&
			    customer.DateOfFirstPurchase.Value.AddYears(_yearsCustomer) >= DateTime.Today)
			{
				var rule = new BirthdayDiscountRule();
				discount = _discount + rule.CalculateCustomerDiscount(customer);
			}

			return discount;
		}
	}
}