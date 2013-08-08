using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Observer.IObserver
{
	public class Unsubscriber : IDisposable
	{
		private readonly List<IObserver<Stock>> _observers;
		private readonly IObserver<Stock> _observer;

		public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
		{
			_observers = observers;
			_observer = observer;
		}

		public void Dispose()
		{
			if (_observers != null && _observers.Contains(_observer))
				_observers.Remove(_observer);
		}
	}
}