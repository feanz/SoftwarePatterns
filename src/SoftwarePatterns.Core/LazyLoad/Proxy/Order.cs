namespace SoftwarePatterns.Core.LazyLoad.Proxy
{
	public class Order
	{
		public virtual Customer Customer { get; set; }
		public int Id { get; set; }

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public string Print()
		{
			return string.Format("Customer Name: {0}", Customer.Name);
		}
	}

	public class OrderFactory
	{
		public OrderProxy CreateOrder(int id)
		{
			return new OrderProxy {Id = id};
		}
	}

	public class OrderProxy : Order
	{
		public override Customer Customer
		{
			get { return base.Customer ?? (base.Customer = new Customer()); }
			set { base.Customer = value; }
		}

		public override bool Equals(object obj)
		{
			var other = obj as Order;
			if (other == null) return false;
			return other.Id == Id;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}