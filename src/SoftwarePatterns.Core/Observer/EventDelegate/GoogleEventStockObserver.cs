using System;

namespace SoftwarePatterns.Core.Observer.EventDelegate
{
	public class GoogleEventStockObserver
	{
		public GoogleEventStockObserver(EventStockTicker eventStockTicker)
		{
			eventStockTicker.StockChange += EventStockTickerOnStockChange;
		}

		private static void EventStockTickerOnStockChange(object sender, StockChangeEventArgs stockChangeEventArgs)
		{
			if (stockChangeEventArgs.CurrentStock.Key.ToLowerInvariant() == "google")
				Console.WriteLine("Google stock: " + stockChangeEventArgs.CurrentStock.Value);
		}
	}
}