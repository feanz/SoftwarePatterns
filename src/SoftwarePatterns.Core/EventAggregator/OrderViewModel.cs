using System;

namespace SoftwarePatterns.Core.EventAggregator
{
	public class OrderViewModel : ISubscriber<OrderCreated>, ISubscriber<OrderSelected>
	{
		public OrderViewModel(IEventAggregator ea)
		{
			ea.Subscribe(this);
		}

		public void OnEvent(OrderCreated e)
		{
			Console.WriteLine("Showing new order screen for {0} in view", e.Order.Name);
		}

		public void OnEvent(OrderSelected e)
		{
			Console.WriteLine("Order {0} has been selected", e.Order.Name);
		}
	}
}