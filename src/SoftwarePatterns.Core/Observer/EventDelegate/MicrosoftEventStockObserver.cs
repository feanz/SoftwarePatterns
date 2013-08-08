using System;

namespace SoftwarePatterns.Core.Observer.EventDelegate
{
	public class MicrosoftEventStockObserver
	{
		public MicrosoftEventStockObserver(EventStockTicker eventStockTicker)
		{
			eventStockTicker.StockChange += EventStockTickerOnStockChange;
		}

		private static void EventStockTickerOnStockChange(object sender, StockChangeEventArgs stockChangeEventArgs)
		{
			var currentStock = stockChangeEventArgs.CurrentStock;
			if (currentStock.Key.ToLowerInvariant() == "msft" && currentStock.Value >= 100)
				Console.WriteLine("MSFT stock is at 100 woow");
		}
	}
}