using System;

namespace SoftwarePatterns.Core.Proxy
{
	public class Order
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime OrderDate { get; set; }
		public int[] OrderDetails { get; set; }
		public int CustomerId { get; set; }
	}
}