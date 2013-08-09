using System;

namespace SoftwarePatterns.Core.Rules
{
	public class DiscountCustomer
	{
		public DateTime DateOfBirth { get; set; }
		public bool IsVeteran { get; set; }
		public DateTime? DateOfFirstPurchase { get; set; }
	}
}