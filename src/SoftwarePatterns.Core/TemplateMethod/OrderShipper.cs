using System;

namespace SoftwarePatterns.Core.TemplateMethod
{
	public abstract class OrderShipper
	{
		protected readonly ShipOrder _order;

		protected OrderShipper(ShipOrder order)
		{
			_order = order;
		}

		public void Ship()
		{
			BeforeOrderShipped();
			VerifyShippingData();
			GetShippingLabelForCarrior();
			PrintLabel();
			AfterOrderShipped();
			LoggOrderShipped();
		}

		protected virtual void LoggOrderShipped()
		{
			Console.WriteLine("Shipping completed for order {0}", _order.Name);
		}

		//hook methods
		protected virtual void BeforeOrderShipped(){}
		protected virtual void AfterOrderShipped(){}

		protected abstract void VerifyShippingData();
		protected abstract void GetShippingLabelForCarrior();

		protected virtual void PrintLabel()
		{
			Console.WriteLine("Shipping");
			Console.WriteLine("Order ID {0}", _order.ID);
			Console.WriteLine("Order Name {0}", _order.Name);
			Console.WriteLine();
		}
	}

	public class ShipOrder
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string ShippingLabel { get; set; }
	}
}