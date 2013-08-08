using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Observer.EventDelegate
{
	public class EventStockTicker
	{
		private KeyValuePair<string, int> _currentStock;

		public void RunTicker()
		{
			var stock = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("Google", 95),
				new KeyValuePair<string, int>("Google", 100),
				new KeyValuePair<string, int>("MSFT", 70),
				new KeyValuePair<string, int>("MSFT", 85),
				new KeyValuePair<string, int>("MSFT", 100)
			};

			stock.ForEach(pair => CurrentStock = pair);
		}

		public KeyValuePair<string, int> CurrentStock
		{
			get { return _currentStock; }
			set
			{
				_currentStock = value;
				OnStockChange(new StockChangeEventArgs(this.CurrentStock));
			}
		}

		public event EventHandler<StockChangeEventArgs> StockChange;

		public virtual void OnStockChange(StockChangeEventArgs e)
		{
			if (StockChange != null)
			{
				StockChange(this, e);
			}
		}
	}
}