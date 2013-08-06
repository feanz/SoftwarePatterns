namespace SoftwarePatterns.Core.EventAggregator
{
	public class OrderCreated
	{
		public OrderCreated(Order order)
		{
			Order = order;
		}

		public Order Order { get; set; }
	}

	public class OrderSelected
	{
		public OrderSelected(Order order)
		{
			Order = order;
		}

		public Order Order { get; set; }
	}
	
	public class OrderSaved
	{
		public OrderSaved(Order order)
		{
			Order = order;
		}

		public Order Order { get; set; }
	}

	public class Order
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Customer { get; set; }
	}

}