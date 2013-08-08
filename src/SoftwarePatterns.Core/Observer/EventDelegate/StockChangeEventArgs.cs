using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Observer.EventDelegate
{
	public class StockChangeEventArgs : EventArgs
	{
		public KeyValuePair<string, int> CurrentStock { get; set; }

		public StockChangeEventArgs(KeyValuePair<string, int> currentStock)
		{
			CurrentStock = currentStock;
		}
	}
}