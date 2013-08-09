using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Rules
{
	public class DiscountCalculator
	{
		private readonly List<IDiscountRule> _discountRules;

		public DiscountCalculator()
		{
			_discountRules = new List<IDiscountRule>
			{
				new BirthdayDiscountRule(),
				new SeniorDiscountRule(),
				new VeteransDiscountRule(),
				new FirstPurchaseRule(),
				new LoyalCustomerDiscount(1,0.05m),
				new LoyalCustomerDiscount(5,0.15m),
				new LoyalCustomerDiscount(5,0.20m)
			};
		}

		public decimal CalculateDiscountPercentage(DiscountCustomer customer)
		{
			decimal discount = 0;

			_discountRules.ForEach(rule =>
			{
				discount = Math.Max(rule.CalculateCustomerDiscount(customer), discount);
			});

			return discount;
		}
	}
}