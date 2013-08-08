using System;
using System.Linq;

namespace SoftwarePatterns.Core.Proxy
{
	public class OrderRepository : Repository<Order>
	{

		public override Order GetById(int id)
		{
			OrderFetched++;
			Console.WriteLine("Going to database to get order");
			return new Order
			{
				Id = id,
				CustomerId = 1,
				OrderDate = DateTime.Now,
				OrderDetails = new[] {1, 2, 34}
			};
		}

		public int OrderFetched { get; set; }
	}
}