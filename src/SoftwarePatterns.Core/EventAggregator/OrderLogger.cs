using System;

namespace SoftwarePatterns.Core.EventAggregator
{
	public class OrderLogger : ISubscriber<OrderSaved>, ISubscriber<OrderCreated>
	{
		public OrderLogger(IEventAggregator ea)
		{
			ea.Subscribe(this);
		}

		public void OnEvent(OrderSaved e)
		{
			Console.WriteLine("Order {0} has been saved", e.Order.Name);
		}

		public void OnEvent(OrderCreated e)
		{
			Console.WriteLine("Order {0} has been created", e.Order.Name);
		}
	}
}