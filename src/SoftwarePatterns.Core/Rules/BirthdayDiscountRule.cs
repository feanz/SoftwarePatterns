using System;

namespace SoftwarePatterns.Core.Rules
{
	public class BirthdayDiscountRule : IDiscountRule
	{
		public decimal CalculateCustomerDiscount(DiscountCustomer customer)
		{
			if (customer.DateOfBirth.Month == DateTime.Today.Month &&
			    customer.DateOfBirth.Day == DateTime.Today.Day)
			{
				return 0.10m;
			}
			return 0;
		}
	}
}