using System;

namespace SoftwarePatterns.Core.TemplateMethod
{
	public class FedexShipper : OrderShipper
	{
		public FedexShipper(ShipOrder order)
			: base(order)
		{
		}

		protected override void VerifyShippingData()
		{
			if (string.IsNullOrEmpty(_order.Name))
				throw new ArgumentException("No valid name provided");
		}

		protected override void GetShippingLabelForCarrior()
		{
			_order.ShippingLabel = String.Format("Fedex Shipping For {0}", _order.Name);
		}
	}
}