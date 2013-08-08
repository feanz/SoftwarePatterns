using System;

namespace SoftwarePatterns.Core.Observer.PubSub
{
	public class GoogleStockObserver : AbstractObservers
	{
		private readonly SimpleStockTicker _ticker;

		public GoogleStockObserver(SimpleStockTicker ticker)
		{
			_ticker = ticker;
			ticker.Register(this);
		}

		public override void Update(AbstractSubject abstractSubject)
		{
			if(_ticker.CurrentStock.Key.ToLowerInvariant() == "google")
				Console.WriteLine("Google stock: " + _ticker.CurrentStock.Value);
		}
	}
}