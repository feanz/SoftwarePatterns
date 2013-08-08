using System.Collections.Generic;

namespace SoftwarePatterns.Core.Observer.PubSub
{
	public abstract class AbstractSubject
	{
		private readonly List<AbstractObservers>  observers = new List<AbstractObservers>();

		public void Register(AbstractObservers observer)
		{
			if (!observers.Contains(observer))
			{
				observers.Add(observer);
			}
		}

		public void UnRegister(AbstractObservers observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			observers.ForEach(observer => observer.Update(this));
		}
	}
}