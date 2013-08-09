using System;

namespace SoftwarePatterns.Core.Rules
{
	public class SeniorDiscountRule : IDiscountRule
	{
		public decimal CalculateCustomerDiscount(DiscountCustomer customer)
		{
			return customer.DateOfBirth < DateTime.Now.AddYears(-65) ? 0.05m : 0;
		}
	}
}