using System;

namespace SoftwarePatterns.Core.Observer.PubSub
{
	public class MicrosftStockObserver : AbstractObservers
	{
		private readonly SimpleStockTicker _ticker;

		public MicrosftStockObserver(SimpleStockTicker ticker)
		{
			_ticker = ticker;
			ticker.Register(this);
		}

		public override void Update(AbstractSubject abstractSubject)
		{
			if(_ticker.CurrentStock.Key.ToLowerInvariant() == "msft" && _ticker.CurrentStock.Value >= 100)
				Console.WriteLine("MSFT is at 100 woow");
		}
	}
}