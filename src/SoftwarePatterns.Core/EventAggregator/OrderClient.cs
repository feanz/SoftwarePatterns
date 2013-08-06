using System.Collections.Generic;
using System.Linq;

namespace SoftwarePatterns.Core.EventAggregator
{
	public class OrderClient
	{
		private readonly IEventAggregator ea;
		private readonly List<Order> orders;

		public OrderClient(IEventAggregator aggregator, List<Order> initialOrders)
		{
			ea = aggregator;
			orders = initialOrders;
		}

		public void CreateOrder(int id, string name, string customer)
		{
			var order = new Order {Id = id, Name = name, Customer = customer};
			orders.Add(order);
			ea.Publish(new OrderCreated(order));
		}


		public void SaveOrder(int id)
		{
			var order = orders.FirstOrDefault(o => o.Id == id);
			if (order != null)
				ea.Publish(new OrderSaved(order));
		}

		public void SelectOrder(int id)
		{
			var order = orders.FirstOrDefault(o => o.Id == id);
			if (order != null)
				ea.Publish(new OrderSelected(order));
		}
	}
}