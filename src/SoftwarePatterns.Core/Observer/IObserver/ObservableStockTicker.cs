using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Observer.IObserver
{
	public class ObservableStockTicker : IObservable<Stock>
	{
		public readonly List<IObserver<Stock>> Observers = new List<IObserver<Stock>>();
		private Stock _currentStock;

		public void RunTicker()
		{
			var stock = new List<Stock>
			{
				new Stock("Google", 95),
				new Stock("Google", 100),
				new Stock("MSFT", 70),
				new Stock("MSFT", 85),
				new Stock("MSFT", 100)
			};

			stock.ForEach(pair => CurrentStock = pair);
			Stop();
		}

		private void Stop()
		{
			Observers.ForEach(observer => observer.OnCompleted());
			Observers.Clear();
		}

		public Stock CurrentStock
		{
			get { return _currentStock; }
			set
			{
				_currentStock = value;
				Notify(_currentStock);
			}
		}

		private void Notify(Stock currentStock)
		{
			Observers.ForEach(observer =>
			{
				if(currentStock.Name == "" || currentStock.Level <0)
					observer.OnError(new Exception("Bad stock very bad stock"));
				else
					observer.OnNext(currentStock);
			});
		}

		public IDisposable Subscribe(IObserver<Stock> observer)
		{
			if (!Observers.Contains(observer))
				Observers.Add(observer);
			return new Unsubscriber(Observers, observer);
		}
	}
}